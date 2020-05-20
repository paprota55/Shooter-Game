using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public string menuMusic = "MenuMusic";
    public GameObject buttonsUI;
    public GameObject gameName;
    public GameObject settingsUI;
    public GameObject highscoresUI;
    public Text volumeText;
    public Slider volumeSlider;
    public Text volumeMText;
    public Slider volumeMSlider;

    private void Start()
    {
        AudioManager.manager.Play(menuMusic);
        volumeSlider.value = AudioManager.manager.GetEffectVolume();
        volumeMSlider.value = AudioManager.manager.GetMusicVolume();
        buttonsUI.SetActive(true);
        gameName.SetActive(true);
        settingsUI.SetActive(false);
        highscoresUI.SetActive(false);

    }
    public void Exit()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    {
        buttonsUI.SetActive(false);
        settingsUI.SetActive(true);
        volumeText.text = ((int)(volumeSlider.value * 100)).ToString();
        volumeMText.text = ((int)(volumeMSlider.value * 100)).ToString();
    }

    public void BackToMenu()
    {
        buttonsUI.SetActive(true);
        settingsUI.SetActive(false);
    }

    public void ChangeEffectVolume()
    {
        float volF = volumeSlider.value;
        AudioManager.manager.UpdateEffectsVolume(volF);
        volF *= 100;
        volumeText.text = ((int)volF).ToString();
    }
    
    public void ChangeMusicVolume()
    {
        float volF = volumeMSlider.value;
        AudioManager.manager.UpdateMusicVolume(volF);
        volF *= 100;
        volumeMText.text = ((int)volF).ToString();
    }

    public void Highscores()
    {
        buttonsUI.SetActive(false);
        gameName.SetActive(false);
        highscoresUI.SetActive(true);
    }
}
