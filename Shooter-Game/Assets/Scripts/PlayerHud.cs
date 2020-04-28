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

    // Start is called before the first frame update
    void Awake()
    {
        ChancesText.text = "CHANCES: " + GameController.getPlayerChances().ToString();
        ScoreText.text = "SCORE: " + GameController.getScore().ToString();
        MoneyText.text = "MONEY: " + GameController.getMoney().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ChancesText.text = "CHANCES: " + GameController.getPlayerChances().ToString();
        ScoreText.text = "SCORE: " + GameController.getScore().ToString();
        MoneyText.text = "MONEY: " + GameController.getMoney().ToString();
    }
}
