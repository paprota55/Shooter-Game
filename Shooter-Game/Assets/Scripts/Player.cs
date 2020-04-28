using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    public float maxHealth = 100;
    public float currentHealth;
    public float damage = 50;
    public void Init()
    {
        currentHealth = maxHealth;
    }
}

public class Player : MonoBehaviour
{
    public PlayerStats playerStats = new PlayerStats();
    [SerializeField]
    private StatusUI status;

    public int atitudeLimitToDie = -10;
    void Update()
    {
        if(transform.position.y <= -20)
        {
            DamagePlayer(playerStats.currentHealth);
        }

        if (status != null)
        {
            status.UpdateHealth(playerStats.currentHealth, playerStats.maxHealth);
        }
    }

    public void DamagePlayer(float damage)
    {
        Debug.Log("Add hit sound");
        playerStats.currentHealth -= damage;

        if(playerStats.currentHealth <= 0)
        {
            GameController.KillPlayer(this);
        }
    }
    private void Start()
    {
        playerStats.Init();
        if (status != null)
        {
            status.UpdateHealth(playerStats.currentHealth, playerStats.maxHealth);
        }
    }
}
