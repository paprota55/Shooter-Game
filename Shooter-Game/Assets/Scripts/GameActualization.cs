using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActualization : MonoBehaviour
{
    bool playerPos;
    bool playerStats;

    private void Start()
    {
        playerPos = false;
        playerStats = false;
    }

    private void Update()
    {
        if(playerPos && playerStats)
        {
            Destroy(this);
        }
    }
}
