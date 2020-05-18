using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets._2D;

public class GameController : MonoBehaviour
{
    public static GameController gm;
    public Transform spawnPoint;
    public GameObject playerObject;
    public GameObject spawnEffect;
    public GameObject deadEffect;
    public int timeToSpawn = 3;
    public static int playerChances;
    public static int score;
    public static int money;
    public string gameMusicName = "GameMusic";
    public string menuMusicName = "MenuMusic";
    public string playerDeadSound = "PlayerDead";
    public string spawnSound = "Respawn";
    public string gameOverSound = "GameOver";
    public string enemyDeadSound = "EnemyDead";

    [SerializeField]
    private int _playerChances = 3;

    [SerializeField]
    private int _score = 0;

    [SerializeField]
    private int _money = 100;

    [SerializeField]
    private GameObject endGameUI;

    [SerializeField]
    private GameObject winGameUI;

    [SerializeField]
    private GameObject waveUI;

    [SerializeField]
    private GameObject shopUI;

    private void Update()
    {
    }

    

    public void IncreaseMoney(int tmp)
    {
        money += tmp;
    }

    public void IncreaseChance(int tmp)
    {
        playerChances += tmp;
    }

    public void IncreaseScore(int tmp)
    {
        score += tmp;
    }
    

    public static int GetMoney()
    {
        return money;
    }
    public static int GetPlayerChances()
    {
        return playerChances;
    }

    public static int GetScore()
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
        AudioManager.manager.Stop(menuMusicName);
        AudioManager.manager.Play(gameMusicName);
    }

    public static void KillPlayer(Player player)
    {
        gm._KillPlayer(player);
    }

    public void _KillPlayer(Player _player)
    {
        AudioManager.manager.Play(playerDeadSound);

        
            Destroy(_player.gameObject);
            GameObject spawnEffectClone = Instantiate(deadEffect, _player.transform.position, _player.transform.rotation) as GameObject;

            Destroy(spawnEffectClone, 1f);
            Destroy(_player.gameObject);
        if (!winGameUI.activeSelf)
        {
            playerChances -= 1;

            if (playerChances > 0)
            {
                AudioManager.manager.Play(spawnSound);
                gm.StartCoroutine(gm.RespawnPlayer());
            }

            else
            {
                gm.EndGame();
            }
        }
    }

    public static void KillEnemy(Enemy enemy)
    {
        gm.UpdatePlayerStash(enemy);
        gm._KillEnemy(enemy);
    }

    public void _KillEnemy(Enemy _enemy)
    {
        AudioManager.manager.Play(enemyDeadSound);

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
        AudioManager.manager.Play(gameOverSound);

        score += money;
        endGameUI.SetActive(true);
        waveUI.SetActive(false);
    }

    public static void WinGame()
    {
        gm._WinGame();
    }

    public void _WinGame()
    {
        AudioManager.manager.Play(gameOverSound);
        DisablePlayer();
        score += money;
        winGameUI.SetActive(true);
        waveUI.SetActive(false);
    }

    public void DisablePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().DisableMove();
        player.GetComponent<Player>().DisableBodyVelocity();
    }

    public IEnumerator RespawnPlayer()
    {
        AudioManager.manager.Play(spawnSound);

        yield return new WaitForSeconds(timeToSpawn);
        Instantiate(playerObject, spawnPoint.position, spawnPoint.rotation);
        GameObject spawnEffectClone = Instantiate(spawnEffect, spawnPoint.position, spawnPoint.rotation) as GameObject;
        Destroy(spawnEffectClone, 3f);
    }
}