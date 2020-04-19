using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gm;
    public Transform spawnPoint;
    public Transform playerObject;
    public GameObject spawnEffect;
    public GameObject deadEffect;
    public CameraShake shake;
    public int timeToSpawn = 3;

    private void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }
    }

    public static void KillPlayer(Player player)
    {
        gm._KillPlayer(player);

    }

    public void _KillPlayer(Player _player)
    {
        Debug.Log("Add death sound");
        Destroy(_player.gameObject);
        GameObject spawnEffectClone = Instantiate(deadEffect, _player.transform.position, _player.transform.rotation) as GameObject;

        Destroy(spawnEffectClone, 1f);
        Destroy(_player.gameObject);

        gm.StartCoroutine(gm.RespawnPlayer());
    }

    public static void KillEnemy(Enemy enemy)
    {
        gm._KillEnemy(enemy);
    }

    public void _KillEnemy(Enemy _enemy)
    {
        Debug.Log("Add death sound");
        GameObject spawnEffectClone = Instantiate(deadEffect, _enemy.transform.position, _enemy.transform.rotation) as GameObject;
        Destroy(spawnEffectClone, 1f);
        Destroy(_enemy.gameObject);
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