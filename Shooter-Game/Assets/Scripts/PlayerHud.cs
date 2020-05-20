using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    [SerializeField]
    private Text ChancesText;

    [SerializeField]
    private Text MoneyText;

    [SerializeField]
    private Text ScoreText;

    // Update is called once per frame
    void Update()
    {
        ChancesText.text = "CHANCES: " + PlayerStats.instance.Chances.ToString();
        ScoreText.text = "SCORE: " + PlayerStats.instance.Score.ToString();
        MoneyText.text = "MONEY: " + PlayerStats.instance.Money.ToString();
    }
}
