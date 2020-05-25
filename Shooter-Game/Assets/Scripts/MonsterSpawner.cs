using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Storage information about wave, how much enemies, which enemies, spawn delay
[System.Serializable]
public class Wave
{
    ///enemy prefab to spawn
    public GameObject enemy;

    ///how much enemies will be spawn
    public int quantity;

    ///delay to next spawn
    [HideInInspector]
    public float delay = 1.0f;

    Wave()
    {
        delay = 0.25f;
    }
}

///Enumerator to select state of spawner - SPAWN actually spawn, WAIT - wait for enemy defeat, COUNT - counting to spawn - PAUSE - game pause
[System.Serializable]
public enum State { SPAWN, WAIT, COUNT, PAUSE };

///Class to managment wave spawn
public class MonsterSpawner : MonoBehaviour
{
    ///store state of spawn
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

    ///List of waves
    public Wave[] wavesList;
    ///List of enemies spawn points
    public GameObject[] spawnPoints;

    ///store which wave is actually spawned
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

    ///If enemies actually live is true
    bool spawn;
    public bool IfSpawn
    {
        get
        {
            return spawn;
        }
    }

    ///Method which is called with object create, if "SavedData" object is exsist then load data from file.
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

    ///Method which write data from loaded object to this object
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

    public float getCounter()
    {
        return counterToNextWave;
    }


    ///Update state of spawner
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
                    GameController.gm.WaveUI.SetActive(true);
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

    ///Update data to spawn next wave
    void arrangementsToNextWave()
    {
        state = State.COUNT;
        counterToNextWave = timeToNextWave;
        whichWave += 1;
        if (whichWave  > wavesList.Length - 1)
        {
            spawn = false;
            GameController.WinGame();
        }
    }

    ///Method check if enemies alive
    bool IsEnemyAlive()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            return false;
        }
        return true;
    }

    ///Using spawn method to spawn enemy, has time delay to invoke spawn monster
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

    ///Random spawn enemy in one of spawn points 
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
