using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///Pause handling class
public class PauseMenuUI : MonoBehaviour
{
    ///References to UI pages and objects like buttons, texts, sliders
    public GameObject buttonsUI;
    public GameObject gameName;
    public GameObject settingsUI;
    public GameObject enterNameUI;
    public InputField playerName;
    public Text volumeText;
    public Slider volumeSlider;
    public Text volumeMText;
    public Slider volumeMSlider;

    private void Start()
    {
        volumeSlider.value = AudioManager.manager.GetEffectVolume();
        volumeMSlider.value = AudioManager.manager.GetMusicVolume();
    }

    ///turn off application
    public void Exit()
    {
        Application.Quit();
    }

    ///Show settings components
    public void Settings()
    {
        buttonsUI.SetActive(false);
        settingsUI.SetActive(true);
        volumeText.text = ((int)(volumeSlider.value*100)).ToString();
        volumeMText.text = ((int)(volumeMSlider.value*100)).ToString();
    }
    
    ///Hide settings and show menu
    public void BackFromSettings()
    {
        buttonsUI.SetActive(true);
        settingsUI.SetActive(false);
    }

    ///Save highscore to the highscores file
    public void SaveName()
    {
        PlayerStats.instance.PlayerName = playerName.text;
        DataManager.SaveNewHighscore(PlayerStats.instance.Score, PlayerStats.instance.PlayerName);
        enterNameUI.SetActive(false);
    }

    ///Turn off game scene and start menu scene
    public void BackToMenu()
    {
        AudioManager.manager.StopAll();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    ///Change SFX volume
    public void ChangeEffectVolume()
    {
        float volF = volumeSlider.value;
        AudioManager.manager.UpdateEffectsVolume(volF);
        volF *= 100;
        volumeText.text = ((int)volF).ToString();
    }

    ///Change music volume
    public void ChangeMusicVolume()
    {
        float volF = volumeMSlider.value;
        AudioManager.manager.UpdateMusicVolume(volF);
        volF *= 100;
        volumeMText.text = ((int)volF).ToString();
    }
}
