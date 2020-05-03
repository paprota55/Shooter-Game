using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStats
{
    public float maxHealth = 100;
    public float currentHealth;
    public float damage = 10;
    public int score = 10;
    public int money = 10;
    public void Init()
    {
        currentHealth = maxHealth;
    }
}

public class Enemy : MonoBehaviour
{
    public EnemyStats enemyStats = new EnemyStats();

    [Header("Optional: ")]
    [SerializeField]
    private StatusUI status;
    void Update()
    {
    }

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

    private void Start()
    {
        enemyStats.Init();
        if(status != null)
        {
            status.UpdateHealth(enemyStats.currentHealth, enemyStats.maxHealth);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if(player != null)
        {
            player.DamagePlayer(enemyStats.damage);
            int randomNumber = Random.Range(0, 1);
            if(randomNumber == 0)
            {
                AudioManager.manager.Play("PlayerHit1");
            }
            else
            {
                AudioManager.manager.Play("PlayerHit2");
            }
        }
    }
}