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
        ChancesText.text = "CHANCES: " + GameController.gm.PlayerChances.ToString();
        ScoreText.text = "SCORE: " + GameController.gm.Score.ToString();
        MoneyText.text = "MONEY: " + GameController.gm.Money.ToString();
    }
}
