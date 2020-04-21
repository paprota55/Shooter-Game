using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    [SerializeField]
    private Text ChancesText;

    // Start is called before the first frame update
    void Awake()
    {
        ChancesText.text = "CHANCES: " + GameController.getPlayerChances().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ChancesText.text = "CHANCES: " + GameController.getPlayerChances().ToString();
    }
}
