using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public string menuMusic = "MenuMusic";
    public GameObject ButtonsUI;
    public GameObject GameName;
    public GameObject SettingsUI;
    public Text VolumeText;
    public Slider VolumeSlider;
    public Text VolumeMText;
    public Slider VolumeMSlider;

    private void Start()
    {
        AudioManager.manager.Play(menuMusic);
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
        ButtonsUI.SetActive(false);
        SettingsUI.SetActive(true);
    }

    public void BackToMenu()
    {
        ButtonsUI.SetActive(true);
        SettingsUI.SetActive(false);
    }

    public void ChangeEffectVolume()
    {
        float volF = VolumeSlider.value;
        AudioManager.manager.UpdateEffectsVolume(volF);
        volF *= 100;
        VolumeText.text = ((int)volF).ToString();
    }
    
    public void ChangeMusicVolume()
    {
        float volF = VolumeMSlider.value;
        AudioManager.manager.UpdateMusicVolume(volF);
        volF *= 100;
        VolumeMText.text = ((int)volF).ToString();
    }
}
