using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Class which is responsible for load data from files. If object exsist other class invoking methods to load data from files
public class GameActualization : MonoBehaviour
{
    ///Check if data are loaded
    public bool playerStats;
    public bool player;
    public bool shop;
    public bool monsterSpawner;
    private void Start()
    {
        playerStats = false;
        player = false;
        shop = false;
        monsterSpawner = false;
        DontDestroyOnLoad(this);
    }

    ///If data are loaded destroy this object
    private void Update()
    {
        if (playerStats&&player&&shop&&monsterSpawner)
        {
            Destroy(this.gameObject);
        }
    }
}
