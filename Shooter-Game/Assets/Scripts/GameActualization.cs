using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class which is responsible for load data from files. If object exist in 
public class GameActualization : MonoBehaviour
{
    public bool playerStats;
    public bool player;
    public bool shop;
    private void Start()
    {
        playerStats = false;
        player = false;
        shop = false;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if(playerStats&&player&&shop)
        {
            Destroy(this.gameObject);
        }
    }
}
