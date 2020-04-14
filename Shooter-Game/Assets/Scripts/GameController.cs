using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gm;
    public Transform spawnPoint;
    public Transform playerObject;
    public GameObject spawnEffect;
    public int timeToSpawn = 3;

    private void Start()
    {
        if (gm == null)
        {
            ;
            gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }
    }

    public static void KillPlayer(Player player)
    {
        Debug.Log("Add death sound");
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());

    }

    public static void KillEnemy(Enemy enemy)
    {
        Debug.Log("Add death sound");
        Destroy(enemy.gameObject);
    }

    public IEnumerator RespawnPlayer()
    {
        Debug.Log("Add spawn sound!");
        yield return new WaitForSeconds(timeToSpawn);
        Instantiate(playerObject, spawnPoint.position, spawnPoint.rotation);
        GameObject spawnEffectClone = Instantiate(spawnEffect, spawnPoint.position, spawnPoint.rotation) as GameObject;
        Destroy(spawnEffectClone, 3f);
    }
}