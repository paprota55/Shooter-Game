﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effect;
    public float damage = 10;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet") { }
        else if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.DamageEnemy(damage);
            }
            AudioManager.manager.Play("BulletDestroy");
            Destroy(gameObject);
            Effect();
        }
        else
        {
            AudioManager.manager.Play("BulletDestroy");
            Destroy(gameObject);
            Effect();
        }
    }

    void Effect()
    {
        GameObject effectPrefab = Instantiate(effect, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(effectPrefab, 0.5f);
    }

    private void SetDamage(float dmg)
    {
        damage = dmg;
    }

    private void Start()
    {
        SetDamage(PlayerStats.instance.Damage);
    }


}