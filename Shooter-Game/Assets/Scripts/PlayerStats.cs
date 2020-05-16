using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public float maxHealth = 100;
    public float currentHealth;
    public float damage = 50;
    public float regen = 1f;
    public float healthRegenRate = 1f;
    public float speed = 10;
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        currentHealth = maxHealth;
    }

    public void Respawn()
    {
        currentHealth = maxHealth;
    }
}
