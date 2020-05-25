using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///Display menu UI and control objects and buttons on screen
public class MenuUI : MonoBehaviour
{
    ///Menu music name
    public string menuMusic = "MenuMusic";
    ///Object which contains standard menu buttons settings,highscores etc.
    public GameObject buttonsUI;
    ///Object which display game name
    public GameObject gameName;
    ///Store settings UI and buttons/sliders to change volume
    public GameObject settingsUI;
    ///Highscores UI which display highscores table
    public GameObject highscoresUI;
    ///text SFX volume value
    public Text volumeText;
    ///SFX volume slider
    public Slider volumeSlider;
    ///text music volume value
    public Text volumeMText;
    ///music volume slider
    public Slider volumeMSlider;
    ///Object which is brought to life if user want load game. Used to load data.
    public GameObject savedData;


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

    ///End application
    public void Exit()
    {
        Application.Quit();
    }

    ///Load new(game) scene with game and deleting old save
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        DataManager.DeleteOldSave();
    }

    ///Create new SavedData object and load new(game) scene
    public void LoadGame()
    {
        if(DataManager.CheckFilesToLoad())
            Instantiate(savedData);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    ///Show settings components
    public void Settings()
    {
        buttonsUI.SetActive(false);
        settingsUI.SetActive(true);
        volumeText.text = ((int)(volumeSlider.value * 100)).ToString();
        volumeMText.text = ((int)(volumeMSlider.value * 100)).ToString();
    }

    ///Hide other UI and show menu UI
    public void BackToMenu()
    {
        settingsUI.SetActive(false);
        highscoresUI.SetActive(false);
        buttonsUI.SetActive(true);
        gameName.SetActive(true);
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

    ///Show highscores UI
    public void Highscores()
    {
        buttonsUI.SetActive(false);
        gameName.SetActive(false);
        highscoresUI.SetActive(true);
    }
}
