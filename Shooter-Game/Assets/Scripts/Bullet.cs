﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") { }
        else if(collision.gameObject.tag == "Enemy")
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
