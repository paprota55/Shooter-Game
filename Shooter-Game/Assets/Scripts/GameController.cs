using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets._2D;

///Game master to management game
public class GameController : MonoBehaviour
{
    ///instance of controller - singleton project template
    public static GameController gm;
    ///player spawn point
    public Transform spawnPoint;
    ///player prefab object
    public GameObject playerObject;
    ///particle system - spawn animation
    public GameObject spawnEffect;
    ///particle system - dead animation
    public GameObject deadEffect;
    ///time to player spawn after death - in seconds
    public int timeToSpawn = 3;
    
    ///sounds names
    public string gameMusicName = "GameMusic";
    public string menuMusicName = "MenuMusic";
    public string playerDeadSound = "PlayerDead";
    public string spawnSound = "Respawn";
    public string gameOverSound = "GameOver";
    public string enemyDeadSound = "EnemyDead";


    ///endGameUI to show/hide end game
    [SerializeField]
    private GameObject endGameUI;

    ///winGameUI to show/hide end game
    [SerializeField]
    private GameObject winGameUI;

    ///waveUI to show/hide wave ui
    [SerializeField]
    private GameObject waveUI;
    public GameObject WaveUI
    {
        get
        {
            return waveUI;
        }
    }

    ///shopUi to show/hide shop
    [SerializeField]
    private GameObject shopUI;

    ///playerUI to show/hide player HUD
    [SerializeField]
    private GameObject playerUI;

    ///enterNameUI to show/hide UI to enter name after end game
    [SerializeField]
    private GameObject enterNameUI;

    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.M))
        {
            PlayerStats.instance.Money += 10000;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerStats.instance.Score += 10000;
        }*/
    }
    
    ///Initialize gm and set UI
    private void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        }

        gm.playerUI.SetActive(true);
        gm.shopUI.SetActive(false);
        gm.enterNameUI.SetActive(false);
        AudioManager.manager.Stop(menuMusicName);
        AudioManager.manager.Play(gameMusicName);
    }

    ///static method to kill player
    public static void KillPlayer(Player player)
    {
        gm._KillPlayer(player);
    }

    ///destroy player object, manipulate playerstats, create instance of dead effect and play dead sound, if lives are greater than 0 create new instance of player object
    public void _KillPlayer(Player _player)
    {
        AudioManager.manager.Play(playerDeadSound);

        
            Destroy(_player.gameObject);
            GameObject spawnEffectClone = Instantiate(deadEffect, _player.transform.position, _player.transform.rotation) as GameObject;

            Destroy(spawnEffectClone, 1f);
            Destroy(_player.gameObject);
        if (!winGameUI.activeSelf)
        {
            PlayerStats.instance.Chances -= 1;

            if (PlayerStats.instance.Chances > 0)
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

    ///static method to kill enemy
    public static void KillEnemy(Enemy enemy)
    {
        gm.UpdatePlayerStash(enemy);
        gm._KillEnemy(enemy);
    }

    ///destroy enemy object, create instance of dead effect and play dead sound
    public void _KillEnemy(Enemy _enemy)
    {
        AudioManager.manager.Play(enemyDeadSound);

        GameObject spawnEffectClone = Instantiate(deadEffect, _enemy.transform.position, _enemy.transform.rotation) as GameObject;
        Destroy(spawnEffectClone, 1f);
        Destroy(_enemy.gameObject);
    }


    ///Update money and score in player stats depending on the values in enemy object
    public void UpdatePlayerStash(Enemy _enemy)
    {
        PlayerStats.instance.Score += _enemy.enemyStats.score;
        PlayerStats.instance.Score += _enemy.enemyStats.money;
    }

    ///Start music, update score in playerStats and show endGameUI and enterNameUI
    public void EndGame()
    {
        AudioManager.manager.Play(gameOverSound);

        PlayerStats.instance.Score += PlayerStats.instance.Money;
        endGameUI.SetActive(true);
        waveUI.SetActive(false);
        enterNameUI.SetActive(true);
    }

    ///static method to show win game
    public static void WinGame()
    {
        gm._WinGame();
    }

    ///Start music, update score in playerStats and show winGameUI and enterNameUI
    public void _WinGame()
    {
        AudioManager.manager.Play(gameOverSound);
        PlayerStats.instance.Score += PlayerStats.instance.Money;
        winGameUI.SetActive(true);
        waveUI.SetActive(false);
        enterNameUI.SetActive(true);
    }

    ///After time to spawn player, create instance of player object, instance of spawn effect
    public IEnumerator RespawnPlayer()
    {
        AudioManager.manager.Play(spawnSound);

        yield return new WaitForSeconds(timeToSpawn);
        Instantiate(playerObject, spawnPoint.position, spawnPoint.rotation);
        GameObject spawnEffectClone = Instantiate(spawnEffect, spawnPoint.position, spawnPoint.rotation) as GameObject;
        Destroy(spawnEffectClone, 3f);
    }

    ///Save data to files. Check game data and save it to files
    public void SaveData()
    {
        ///Save PlayerStats
        DataManager.SavePlayerStats(PlayerStats.instance);

        ///Save Player position
        GameObject data = GameObject.FindGameObjectWithTag("Player");
        if (data != null)
        {
            DataManager.SavePlayer(data.transform.position);
        }
        else
        {
            DataManager.SavePlayer(spawnPoint.position);
        }

        ///Save shop prices
        if (shopUI != null)
        {
            DataManager.SaveShop(shopUI.GetComponent<Shop>());
        }
        else
        {
            DataManager.SaveShop(new Shop());
        }

        ///Save monster spawner state
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");        
        if(this.GetComponent<MonsterSpawner>() != null)
        {
            DataManager.SaveMonsterSpawner(this.GetComponent<MonsterSpawner>(),enemies);
        }


    }
}