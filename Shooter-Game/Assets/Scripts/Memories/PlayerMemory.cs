using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMemory
{
    public float[] pos;

    public PlayerMemory()
    {

    }
    public PlayerMemory(Vector3 data)
    {
        pos = new float[3];
        pos[0] = data.x;
        pos[1] = data.y;
        pos[2] = data.z;
    }
}
