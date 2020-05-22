using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemy;
    public int quantity;
    [HideInInspector]
    public float delay = 1.0f;

    Wave()
    {
        delay = 0.25f;
    }
}

[System.Serializable]
public enum State { SPAWN, WAIT, COUNT, PAUSE };

public class MonsterSpawner : MonoBehaviour
{
    private State state = State.COUNT;
    public State WaveState
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
        }
    }
    public Wave[] wavesList;
    public GameObject[] spawnPoints;
    private int whichWave = 0;
    public int WaveNumber
    {
        get
        {
            return whichWave;
        }
        set
        {
            whichWave = value;
        }
    }
    public float timeToNextWave = 8f;
    private float counterToNextWave;

    bool spawn;
    public bool IfSpawn
    {
        get
        {
            return spawn;
        }
    }

    private void Start()
    {
        GameObject save = GameObject.FindGameObjectWithTag("SavedData");
        if (save != null)
        {
            save.GetComponent<GameActualization>().monsterSpawner = true;
            LoadData(DataManager.LoadMonsterSpawner());            
        }
        else
        {
            spawn = true;
        }

        counterToNextWave = timeToNextWave;
    }

    void LoadData(MonsterSpawnerMemory data)
    {
        spawn = data.spawn;
        whichWave = data.whichWave;
        state = (State)data.state;
        
        if(data.enemiesHealth != null)
        {
            int j = 0;
            for (int i = 0; i<data.enemiesHealth.Length;i++)
            {
                GameObject newEnemy = Instantiate(wavesList[whichWave].enemy);
                newEnemy.GetComponent<Enemy>().enemyStats.currentHealth = data.enemiesHealth[i];
                newEnemy.transform.position = new Vector3(data.positions[j], data.positions[j+1], data.positions[j+2]);
                j += 3;
            }
        }
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
        if (spawn)
        {
            if (state == State.WAIT)
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

            if (counterToNextWave <= 0)
            {
                if (state == State.COUNT)
                {

                    StartCoroutine(Spawn(wavesList[whichWave]));
                }
            }
            else
            {
                if(state != State.PAUSE)
                counterToNextWave -= Time.deltaTime;
            }
        }
    }

    void arrangementsToNextWave()
    {
        state = State.COUNT;
        GameController.gm.WaveUI.SetActive(true);
        counterToNextWave = timeToNextWave;
        whichWave += 1;
        if (whichWave  > wavesList.Length - 1)
        {
            spawn = false;
            GameController.WinGame();
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
            yield return new WaitForSeconds(wave.delay);
            AudioManager.manager.Play("Spawn");
            SpawnEnemy(wave.enemy);
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
