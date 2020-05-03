using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class which is responsible for read fire buttons and create instance of bullet
public class Shooting : MonoBehaviour
{
    //start bullet position
    public Transform startPosition;

    //bullet prefab which contains object which will be throw
    public GameObject bulletPrefab;


    public float speed = 20f;

    //Clock from one shoot to next shot
    private float time;
    //Delay which is responsible for block spawning too many bullets
    public float delayTime = 0.1f;

    //variable which allows to auto spawn bullets
    bool autoShooting = false;
    void Start()
    {
        time = 0;    
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2")) autoShooting = !autoShooting; //if mouse right click then set auto shooting to false or true;
        if (Input.GetButton("Fire1") || autoShooting)   // if fire is true then check the delay time to next shoot
        {
            if (time + delayTime < Time.time || Input.GetButtonDown("Fire1"))   //if fire is true and delay is good then update shoot clock, play sound and make "Shoot"
            {
                AudioManager.manager.Play("Shot");
                Shoot();
                time = Time.time;
            }
        }
    }

    //method which is responsible for spawning bullet and give him force, if bullet don't touch obstacles or enemies above 2 seconds then destroy self
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, startPosition.position, startPosition.rotation);
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(startPosition.right * speed, ForceMode2D.Impulse);
        Destroy(bullet, 2f);
    }
}