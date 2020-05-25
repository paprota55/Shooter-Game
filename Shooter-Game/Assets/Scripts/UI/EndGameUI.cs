using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///Display UEndGameI and control objects and buttons on screen
public class EndGameUI : MonoBehaviour
{
    ///store score value and display to screen
    public Text scoreText;
    ///name game music
    public string gameMusicName = "GameMusic";

    ///End Application
    public void Exit()
    {
        Application.Quit();
    }

    ///Load current scene one more time and start new game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); /// loads current scene
    }

    ///Load menu scene
    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    ///Set score value to display on the screen
    public void SetScore()
    {
        scoreText.text = "YOUR SCORE: " + PlayerStats.instance.Score.ToString();
    }

    ///update once per frame
    private void Update()
    {
        SetScore();
    }

    ///If object create start playing music
    private void Start()
    {
        AudioManager.manager.Stop(gameMusicName);
    }
}

