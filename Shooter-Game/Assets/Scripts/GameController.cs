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
    private int _playerChances = 3;
    public int PlayerChances
    {
        get
        {
            return _playerChances;
        }
        set
        {
            _playerChances = value;
        }
    }

    private int _score = 0;
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }

    private int _money = 100;
    public int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
        }
    }
    public string gameMusicName = "GameMusic";
    public string menuMusicName = "MenuMusic";
    public string playerDeadSound = "PlayerDead";
    public string spawnSound = "Respawn";
    public string gameOverSound = "GameOver";
    public string enemyDeadSound = "EnemyDead";

    [SerializeField]
    private GameObject endGameUI;

    [SerializeField]
    private GameObject winGameUI;

    [SerializeField]
    private GameObject waveUI;

    [SerializeField]
    private GameObject shopUI;

    [SerializeField]
    private GameObject playerUI;

    [SerializeField]
    private GameObject enterNameUI;

    private void Update()
    {
    }

    

    public void IncreaseMoney(int tmp)
    {
        Money += tmp;
    }

    public void IncreaseChance(int tmp)
    {
        PlayerChances += tmp;
    }

    public void IncreaseScore(int tmp)
    {
        Score += tmp;
    }
    
    private void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }

        playerUI.SetActive(true);
        enterNameUI.SetActive(false);
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
            _playerChances -= 1;

            if (_playerChances > 0)
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
        _score += _enemy.enemyStats.score;
        _money += _enemy.enemyStats.money;
    }

    public void EndGame()
    {
        AudioManager.manager.Play(gameOverSound);

        _score += _money;
        endGameUI.SetActive(true);
        waveUI.SetActive(false);
        enterNameUI.SetActive(true);
    }

    public static void WinGame()
    {
        gm._WinGame();
    }

    public void _WinGame()
    {
        AudioManager.manager.Play(gameOverSound);
        _score += _money;
        winGameUI.SetActive(true);
        waveUI.SetActive(false);
        enterNameUI.SetActive(true);
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