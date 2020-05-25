using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Class to storage enemy statistics and value of money which drop from him and score which give if die
[System.Serializable]
public class EnemyStats
{
    public float maxHealth = 100;
    public float currentHealth;
    public float damage = 10;
    public int score = 10;
    public int money = 10;

    ///initialize start enemy health
    public void Init()
    {
        currentHealth = maxHealth;
    }
}

///Class to manipulate enemy object
public class Enemy : MonoBehaviour
{
    ///instance of EnemyStats
    public EnemyStats enemyStats = new EnemyStats();

    ///Status UI to display health
    [SerializeField]
    private StatusUI status;

    ///Decrease enemy health and if health is lower than 0, kill enemy. Update statusUI
    public void DamageEnemy(float damage)
    {
        Debug.Log("Add hit sound");
        enemyStats.currentHealth -= damage;

        if (enemyStats.currentHealth <= 0)
        {
            GameController.KillEnemy(this);
        }

        if (status != null)
        {
            status.UpdateHealth(enemyStats.currentHealth, enemyStats.maxHealth);
        }
        else Debug.LogError("Player haven't UI!");
    }

    ///Initialize EnemyStats instance and update enemy status ui
    private void Start()
    {
        enemyStats.Init();
        if(status != null)
        {
            status.UpdateHealth(enemyStats.currentHealth, enemyStats.maxHealth);
        }
    }

    ///If collision with player then damage player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if(player != null)
        {
            player.DamagePlayer(enemyStats.damage);
        }
    }

    ///if destroy object then increase player money
    private void OnDestroy()
    {
        PlayerStats.instance.Money += enemyStats.money;
    }
}