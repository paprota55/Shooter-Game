using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class MonsterSpawnerMemory 
{
    public float[] positions;
    public float[] enemiesHealth;
    public int state;
    public int whichWave;
    public bool spawn;

    public MonsterSpawnerMemory()
    {

    }

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
