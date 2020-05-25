using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///Class to display player status
public class StatusUI : MonoBehaviour
    ///Sprite which changes dependig on life
{   [SerializeField]
    private RectTransform healthBar;
    ///Sprite which changes dependig on life
    [SerializeField]
    private RectTransform redHealthBar;
    ///Text which display current health and max health
    [SerializeField]
    private Text healthText;

    private void Start()
    {
        if (healthText == null) Debug.LogError("No Enemy Text!");
        if (healthBar == null) Debug.LogError("No Health Bar!");
        if (redHealthBar == null) Debug.LogError("No Red Health Bar!");
    }

    ///Method to resize sprites and update text
    public void UpdateHealth(float currentHp, float maxHp)
    {
        float percentHealth = currentHp / maxHp;
        float redHealth = 1;
        redHealth -= percentHealth;

        healthBar.localScale = new Vector3(percentHealth, healthBar.localScale.y, healthBar.localScale.z);
        redHealthBar.localScale = new Vector3(redHealth, redHealthBar.localScale.y, redHealthBar.localScale.z);
        healthText.text = currentHp + "/" + maxHp + " HP";
    }
}
