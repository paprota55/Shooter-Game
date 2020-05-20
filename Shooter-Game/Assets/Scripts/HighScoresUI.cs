using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoresUI : MonoBehaviour
{
    Highscores scores;

    [SerializeField]
    private Text[] list;

    private void Start()
    {
        scores = DataManager.LoadHighscores();
        WriteToUI();
    }

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
