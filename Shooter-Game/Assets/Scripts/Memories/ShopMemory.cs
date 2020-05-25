using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Class to storage data from Shop game class
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
    ///constructor to fill data to save
    public ShopMemory(Shop data)
    {
        healthPrice = data.HealthPrice;
        speedPrice = data.SpeedPrice;
        damagePrice = data.DamagePrice;
        chancePrice = data.ChancePrice;
    }
}
