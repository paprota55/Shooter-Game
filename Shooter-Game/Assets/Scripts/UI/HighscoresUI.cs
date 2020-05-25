using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///UI to display highscores on screen
public class HighscoresUI : MonoBehaviour
{
    ///store data - highscores
    HighscoresMemory scores;

    ///Text list which display highscores on the screen
    [SerializeField]
    private Text[] list;
    
    ///Load highscores from file
    private void Start()
    {
        scores = DataManager.LoadHighscores();
        WriteToUI();
    }

    ///Write highscores to text list from loaded data (highscores)
    private void WriteToUI()
    {
        int j = 0;
        for (int i = 0; i < list.Length; i+=2)
        {
            list[i].text = scores.GetNames()[j];
            list[i + 1].text = scores.GetResults()[j].ToString();
            j++;
        }
    }
}
