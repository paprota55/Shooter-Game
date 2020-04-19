using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{   [SerializeField]
    private RectTransform healthBar;
    [SerializeField]
    private Text healthText;

    private void Start()
    {
        if (healthText == null) Debug.LogError("No Enemy Text!");
        if (healthBar == null) Debug.LogError("No Health Bar!");
    }

    public void UpdateHealth(float currentHp, float maxHp)
    {
        float percentHealth = currentHp / maxHp;

        healthBar.localScale = new Vector3(percentHealth, healthBar.localScale.y, healthBar.localScale.z);
        healthText.text = currentHp + "/" + maxHp + " HP";
    }
}
