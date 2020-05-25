using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


///Class to storage data from MonsterSpawner game class
[System.Serializable]
public class MonsterSpawnerMemory 
{
    ///Store enemies positions [x][y][z]
    public float[] positions;
    ///Store enemies health
    public float[] enemiesHealth;
    ///Store state of monster spawner WAIT, PAUSE, SPAWN, COUNT
    public int state;
    ///Store which wave was in game when saved
    public int whichWave;
    ///Store if actually spawn
    public bool spawn;

    public MonsterSpawnerMemory()
    {

    }

    ///2 args constructor to fill data to save
    public MonsterSpawnerMemory(MonsterSpawner data, GameObject[] list)
    {
        state = (int)data.WaveState;
        whichWave = data.WaveNumber;
        spawn = data.IfSpawn;

        if(list != null)
        {
            positions = new float[3 * list.Length];
            enemiesHealth = new float[list.Length];

            for(int i = 0; i<list.Length;i++)
            {
                enemiesHealth[i] = list[i].GetComponent<Enemy>().enemyStats.currentHealth;
            }

            for(int i = 0; i<positions.Length;i+=3)
            {
                positions[i] = list[i / 3].transform.position.x;
                positions[i+1] = list[i / 3].transform.position.y;
                positions[i+2] = list[i / 3].transform.position.z;
            }
        }
        else
        {
            positions = null;
            enemiesHealth = null;
        }
    }
}
