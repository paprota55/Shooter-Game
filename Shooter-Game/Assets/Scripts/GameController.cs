using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gm;
    public Transform spawnPoint;
    public Transform playerObject;
    public GameObject spawnEffect;
    public GameObject deadEffect;
    public int timeToSpawn = 3;
    public static int playerChances;
    public static int score;
    public static int money;

    [SerializeField]
    private int _playerChances = 3;

    [SerializeField]
    private int _score = 0;

    [SerializeField]
    private int _money = 0;

    [SerializeField]
    private GameObject endGameUI;

    public static int getMoney()
    {
        return money;
    }
    public static int getPlayerChances()
    {
        return playerChances;
    }

    public static int getScore()
    {
        return score;
    }

    private void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }

        playerChances = _playerChances;
        score = _score;
        money = _money;
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

        playerChances -= 1;
        if (playerChances > 0)
        {
            gm.StartCoroutine(gm.RespawnPlayer());
        }

        else
        {
            gm.EndGame();
        }
    }

    public static void KillEnemy(Enemy enemy)
    {
        gm.UpdatePlayerStash(enemy);
        gm._KillEnemy(enemy);
    }

    public void _KillEnemy(Enemy _enemy)
    {
        Debug.Log("Add death sound");
        GameObject spawnEffectClone = Instantiate(deadEffect, _enemy.transform.position, _enemy.transform.rotation) as GameObject;
        Destroy(spawnEffectClone, 1f);
        Destroy(_enemy.gameObject);
    }

    public void UpdatePlayerStash(Enemy _enemy)
    {
        score += _enemy.enemyStats.score;
        money += _enemy.enemyStats.money;
    }

    public void EndGame()
    {
        endGameUI.SetActive(true);
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