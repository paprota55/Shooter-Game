using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text moneyText;
    public Text healthText;
    public Text speedText;
    public Text damageText;
    public Text chanceText;
    public Text healthPriceText;
    public Text speedPriceText;
    public Text damagePriceText;
    public Text chancePriceText;
    private int money;
    private int chances;
    private int healthPrice;
    private int speedPrice;
    private int damagePrice;
    private int chancePrice;

    public float priceRate = 0.5f;

    private float healthRate = 0.5f;
    private float speedRate = 0.01f;
    private float damageRate = 0.1f;
    private int chanceRate = 1;

    private void Start()
    {
        healthPrice = 100;
        speedPrice = 100;
        damagePrice = 100;
        chancePrice = 500;
    }

    private void Update()
    {
        money = GameController.GetMoney();
        chances = GameController.GetPlayerChances();
        moneyText.text = "MONEY: " + money;
        healthText.text = "HEALTH: " + PlayerStats.instance.maxHealth;
        speedText.text = "SPEED: " + PlayerStats.instance.speed;
        damageText.text = "DAMAGE: " + PlayerStats.instance.damage;
        chanceText.text = "CHANCES: " + chances;
        healthPriceText.text = healthPrice.ToString();
        speedPriceText.text = speedPrice.ToString();
        damagePriceText.text = damagePrice.ToString();
        chancePriceText.text = chancePrice.ToString();
    }

    public void BuyHealth()
    {
        if(money >= healthPrice)
        {
            PlayerStats.instance.maxHealth += PlayerStats.instance.maxHealth * healthRate;
            money -= healthPrice;
            GameController.gm.IncreaseMoney(-healthPrice);
            healthPrice += (int)(priceRate*healthPrice);
        }
    }

    public void BuySpeed()
    {
        if (money >= speedPrice)
        {
            PlayerStats.instance.speed += PlayerStats.instance.speed * speedRate;
            money -= speedPrice;
            GameController.gm.IncreaseMoney(-speedPrice);
            speedPrice += (int)(priceRate * speedPrice);
        }
    }

    public void BuyChance()
    {
        if (money >= chancePrice)
        {
            GameController.gm.IncreaseChance(chanceRate);
            money -= chancePrice;
            GameController.gm.IncreaseMoney(-chancePrice);
            chancePrice += (int)(priceRate * chancePrice);
        }
    }

    public void BuyDamage()
    {
        if (money >= healthPrice)
        {
            PlayerStats.instance.damage += PlayerStats.instance.damage * damageRate;
            money -= damagePrice;
            GameController.gm.IncreaseMoney(-damagePrice);
            damagePrice += (int)(priceRate * damagePrice);
        }
    }
}
