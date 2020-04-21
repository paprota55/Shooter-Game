using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemy;
    public int quantity;
    public float delay;
    public int whichWave;
}

public enum State { SPAWN, WAIT, COUNT };

public class MonsterSpawner : MonoBehaviour
{
    private State state = State.COUNT;
    public Wave[] wavesList;
    public GameObject[] spawnPoints;
    private int whichWave = 0;
    public float timeToNextWave = 8f;
    private float counterToNextWave;

    private void Start()
    {
        counterToNextWave = timeToNextWave;
    }

    public State getState()
    {
        return state;
    }

    public float getCounter()
    {
        return counterToNextWave;
    }

    public int getWaveNumber()
    {
        return whichWave;
    }

    private void Update()
    {
        if(state == State.WAIT)
        {
            if (IsEnemyAlive() == false)
            {

                arrangementsToNextWave();
                return;
            }
            else
            {
                return;
            }
        }

        if(counterToNextWave <= 0)
        {
            if(state == State.COUNT)
            {
                StartCoroutine(Spawn(wavesList[whichWave]));
            }
        }
        else
        {
            counterToNextWave -= Time.deltaTime;
        }
    }

    void arrangementsToNextWave()
    {
        state = State.COUNT;
        counterToNextWave = timeToNextWave;
        whichWave += 1;
        if (whichWave  > wavesList.Length - 1)
        {
            whichWave = 0;
        }
    }

    bool IsEnemyAlive()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            return false;
        }
        return true;
    }

    IEnumerator Spawn(Wave wave)
    {
        state = State.SPAWN;

        for(int i = 0;i<wave.quantity;i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(wave.delay);
        }

        state = State.WAIT;
        yield break;
    }

    private void SpawnEnemy(GameObject _enemy)
    {
        if (spawnPoints.Length > 0)
        {
            GameObject _spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(_enemy, _spawnPoint.transform.position, _spawnPoint.transform.rotation);
        }
        else
        {
            Debug.LogError("Spawn points don't exists!");
        }
    }
}
