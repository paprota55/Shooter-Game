using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
using UnityEditor;

/*[System.Serializable]
public class PlayerStats
{
    public float maxHealth = 100;
    public float currentHealth;
    public float damage = 50;
    public void init()
    {
        currentHealth = maxHealth;
    }
}*/

public class Player : MonoBehaviour
{
    private PlayerStats playerStats;
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

    void RegenHealth()
    {
        if(playerStats.maxHealth > playerStats.currentHealth)
        playerStats.currentHealth += playerStats.regen;
    }

    private void Start()
    {
        playerStats = PlayerStats.instance;
        playerStats.Respawn();
        if (status != null)
        {
            status.UpdateHealth(playerStats.currentHealth, playerStats.maxHealth);
        }
        InvokeRepeating("RegenHealth", playerStats.healthRegenRate, playerStats.healthRegenRate); 
    }
}
