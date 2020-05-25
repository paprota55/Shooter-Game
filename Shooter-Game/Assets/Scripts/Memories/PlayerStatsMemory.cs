using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Class to storage data from PlayerStats game class
[System.Serializable]
public class PlayerStatsMemory
{
    ///player name
    public string name;
    ///player max health
    public float maxHealth;
    ///player current health
    public float currentHealth;
    ///player chances
    public int chances;
    ///player score
    public int score;
    ///player money
    public int money;
    ///player damage
    public float damage;
    ///player regen - how much hp regen per rate
    public float regen;
    ///player health regen rate - time to next regen
    public float healthRegenRate;
    ///player speed
    public float speed;

    public PlayerStatsMemory()
    {

    }

    ///2 args constructor to fill data to save
    public PlayerStatsMemory(PlayerStats data)
    {
        name = data.PlayerName;
        maxHealth = data.MaxHealth;
        currentHealth = data.CurrentHealth;
        chances = data.Chances;
        score = data.Score;
        money = data.Money;
        damage = data.Damage;
        regen = data.Regen;
        healthRegenRate = data.HealthRegenRate;
        speed = data.Speed;
    }
}
