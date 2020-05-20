using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStatsMemory
{
    public string name;
    public float maxHealth;
    public float currentHealth;
    public int chances;
    public int score;
    public int money;
    public float damage;
    public float regen;
    public float healthRegenRate;
    public float speed;

    public PlayerStatsMemory()
    {

    }
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
        Debug.LogError("Mam hajsu przy zapisie: " + money);
    }
}
