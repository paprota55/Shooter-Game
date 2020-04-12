using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform startPosition;
    public GameObject bulletPrefab;
    
    public float speed = 20f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Add shoot sound!");
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, startPosition.position, startPosition.rotation);
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(startPosition.right * speed, ForceMode2D.Impulse);
        Destroy(bullet, 2f);
    }
}
