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
    private int healthPrice;
    public int HealthPrice
    {
        get
        {
            return healthPrice;
        }
        set
        {
            healthPrice = value;
        }
    }
    private int speedPrice;
    public int SpeedPrice
    {
        get
        {
            return speedPrice;
        }
        set
        {
            speedPrice = value;
        }
    }
    private int damagePrice;
    public int DamagePrice
    {
        get
        {
            return damagePrice;
        }
        set
        {
            damagePrice = value;
        }
    }
    private int chancePrice;
    public int ChancePrice
    {
        get
        {
            return chancePrice;
        }
        set
        {
            chancePrice = value;
        }
    }
    private int money;
    public float priceRate = 0.25f;
    private float healthRate = 0.5f;
    private float speedRate = 0.01f;
    private float damageRate = 0.1f;
    private int chanceRate = 1;

    private void Start()
    {
        GameObject save = GameObject.FindGameObjectWithTag("SavedData");
        if (save != null)
        {
            LoadData(DataManager.LoadShop());
            save.GetComponent<GameActualization>().shop = true;
        }
        else
        {
            healthPrice = 100;
            speedPrice = 100;
            damagePrice = 100;
            chancePrice = 500;
        }

    }

    private void Update()
    {
        money = PlayerStats.instance.Money;
        moneyText.text = "MONEY: " + money;
        healthText.text = "HEALTH: " + PlayerStats.instance.MaxHealth;
        speedText.text = "SPEED: " + PlayerStats.instance.Speed;
        damageText.text = "DAMAGE: " + PlayerStats.instance.Damage;
        chanceText.text = "CHANCES: " + PlayerStats.instance.Chances;
        healthPriceText.text = healthPrice.ToString();
        speedPriceText.text = speedPrice.ToString();
        damagePriceText.text = damagePrice.ToString();
        chancePriceText.text = chancePrice.ToString();
    }

    public void BuyHealth()
    {
        if(money >= healthPrice)
        {
            PlayerStats.instance.MaxHealth += (int)(PlayerStats.instance.MaxHealth * healthRate);
            money -= healthPrice;
            PlayerStats.instance.Money -= healthPrice;
            healthPrice += (int)(priceRate*healthPrice);
        }
    }

    public void BuySpeed()
    {
        if (money >= speedPrice)
        {
            PlayerStats.instance.Speed += PlayerStats.instance.Speed * speedRate;
            PlayerStats.instance.Speed = Mathf.Round(PlayerStats.instance.Speed * 100f) / 100f;
            money -= speedPrice;
            PlayerStats.instance.Money -= speedPrice;
            speedPrice += (int)(priceRate * speedPrice);
        }
    }

    public void BuyChance()
    {
        if (money >= chancePrice)
        {
            PlayerStats.instance.Chances +=chanceRate;
            money -= chancePrice;
            PlayerStats.instance.Money -= chancePrice;
            chancePrice += (int)(priceRate * chancePrice);
        }
    }

    public void BuyDamage()
    {
        if (money >= damagePrice)
        {
            PlayerStats.instance.Damage += (int)(PlayerStats.instance.Damage * damageRate);
            PlayerStats.instance.Damage = Mathf.Round(PlayerStats.instance.Damage * 100f) / 100f;
            money -= damagePrice;
            PlayerStats.instance.Money -= damagePrice;
            damagePrice += (int)(priceRate * damagePrice);
        }
    }

    void LoadData(ShopMemory data)
    {
        healthPrice = data.healthPrice;
        speedPrice = data.speedPrice;
        damagePrice = data.damagePrice;
        chancePrice = data.chancePrice;
    }
}
