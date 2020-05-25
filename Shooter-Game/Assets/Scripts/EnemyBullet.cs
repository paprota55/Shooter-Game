using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Class to manipulate enemy bullet object
public class EnemyBullet : MonoBehaviour
{
    ///prefab which symbolizes bullet destroy
    public GameObject effect;

    ///default bullet damage
    public float damage = 10;

    ///If bullet touch object destroy yourself
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Bullet") { }
        else if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Effect();
        }
        else if (collision.gameObject.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.DamagePlayer(damage);
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

    ///Spawn effect object - particle system
    void Effect()
    {
        GameObject effectPrefab = Instantiate(effect, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(effectPrefab, 0.5f);
    }
}
