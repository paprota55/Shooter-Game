using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    public float Health = 100;

}

public class Player : MonoBehaviour
{
    public PlayerStats playerStats = new PlayerStats();

    public int atitudeLimitToDie = -10;
    void Update()
    {
        if(transform.position.y <= -20)
        {
            attackPlayer(playerStats.Health);
        }
    }

    public void attackPlayer(float damage)
    {
        playerStats.Health -= damage;

        if(playerStats.Health <=0)
        {
            GameController.kill(this);
        }
    }
}
