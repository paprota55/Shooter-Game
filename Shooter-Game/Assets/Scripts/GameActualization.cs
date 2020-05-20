using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActualization : MonoBehaviour
{
    public bool playerStats;

    private void Start()
    {
        playerStats = false;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if(playerStats)
        {
            Destroy(this.gameObject);
        }
    }
}
