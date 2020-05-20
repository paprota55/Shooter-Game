using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{

    public Text scoreText;
    public string gameMusicName = "GameMusic";
    public void Exit()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SetScore()
    {
        scoreText.text = "YOUR SCORE: " + PlayerStats.instance.Score.ToString();
    }

    private void Update()
    {
        SetScore();
    }

    private void Start()
    {
        AudioManager.manager.Stop(gameMusicName);
    }
}

