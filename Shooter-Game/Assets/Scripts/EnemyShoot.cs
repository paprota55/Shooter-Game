using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    ///bullet prefab which contains object which will be throw
    public GameObject bulletPrefab;

    //target position where bullet should go
    private Transform target;

    //speed of bullet
    public float speed = 10f;

    ///Clock from one shoot to next shot
    private float time;
    ///Delay which is responsible for block spawning too many bullets
    public float delayTime = 2f;

    //Delay between player searches
    private float searchDelay = 1f;

    void Start()
    {
        time = 0;
    }

    void Update()
    {

        if (time + delayTime < Time.time && IfTargetReady())   ///if fire is true and delay is good then update shoot clock, play sound and make "Shoot"
        {
            AudioManager.manager.Play("Shot");
            Shoot();
            time = Time.time;
        }
    }

    ///method which is responsible for spawning bullet and give him force, if bullet don't touch obstacles or enemies above 2 seconds then destroy self
    void Shoot()
    {
        if (target != null)
        {
            Vector2 moveDirection = (target.transform.position - transform.position).normalized * speed;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();
            rigidBody.velocity = new Vector2(moveDirection.x, moveDirection.y);
            Destroy(bullet, 2f);

        }
    }

    //Check if player is on scene
    bool IfTargetReady()
    {
        if (searchDelay <= Time.time)
        {
            GameObject newPlayer = GameObject.FindGameObjectWithTag("Player");
            if (newPlayer != null)
            {
                target = newPlayer.transform;
                return true;
            }
            searchDelay = Time.time + 1f;
        }
        return false;
    }
}
