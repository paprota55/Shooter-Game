﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{

    public GameObject buttonsUI;
    public GameObject gameName;
    public GameObject settingsUI;
    public Text volumeText;
    public Slider volumeSlider;
    public Text volumeMText;
    public Slider volumeMSlider;

    public void Exit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        buttonsUI.SetActive(false);
        settingsUI.SetActive(true);
        volumeText.text = (volumeSlider.value*100).ToString();
        volumeMText.text = (volumeMSlider.value*100).ToString();
    }

    public void BackFromSettings()
    {
        buttonsUI.SetActive(true);
        settingsUI.SetActive(false);
    }

    public void BackToMenu()
    {
        AudioManager.manager.StopAll();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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
}
