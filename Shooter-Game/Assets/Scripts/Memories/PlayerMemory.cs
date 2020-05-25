using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Class to storage data from Player game class
[System.Serializable]
public class PlayerMemory
{
    ///Store player position [x][y][z]
    public float[] pos;

    public PlayerMemory()
    {

    }

    ///constructor to fill data to save
    public PlayerMemory(Vector3 data)
    {
        pos = new float[3];
        pos[0] = data.x;
        pos[1] = data.y;
        pos[2] = data.z;
    }
}
