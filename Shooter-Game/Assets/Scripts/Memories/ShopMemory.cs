using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopMemory
{
    public int healthPrice;
    public int speedPrice;
    public int damagePrice;
    public int chancePrice;

    public ShopMemory()
    {

    }
    public ShopMemory(Shop data)
    {
        healthPrice = data.HealthPrice;
        speedPrice = data.SpeedPrice;
        damagePrice = data.DamagePrice;
        chancePrice = data.ChancePrice;
    }
}
