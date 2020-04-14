using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStats
{
    public float Health = 100;

}

public class Enemy : MonoBehaviour
{
    public EnemyStats enemyStats = new EnemyStats();

    void Update()
    {
    }

    public void DamageEnemy(float damage)
    {
        Debug.Log("Add hit sound");
        enemyStats.Health -= damage;

        if (enemyStats.Health <= 0)
        {
            GameController.KillEnemy(this);
        }
    }
}