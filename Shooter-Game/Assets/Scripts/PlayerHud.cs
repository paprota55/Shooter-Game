using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///Class to display information on screen
public class PlayerHud : MonoBehaviour
{
    ///Texts which store information about data from PlayerStats
    [SerializeField]
    private Text ChancesText;

    [SerializeField]
    private Text MoneyText;

    [SerializeField]
    private Text ScoreText;

    /// Update Text objects
    void Update()
    {
        ChancesText.text = "CHANCES: " + PlayerStats.instance.Chances.ToString();
        ScoreText.text = "SCORE: " + PlayerStats.instance.Score.ToString();
        MoneyText.text = "MONEY: " + PlayerStats.instance.Money.ToString();
    }
}
