using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    private string _playerName = "NoName";
    public string PlayerName
    {
        get
        {
            return _playerName;
        }
        set
        {
            _playerName = value;
        }
    }

    private float _maxHealth = 100;
    public float MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    private float _currentHealth;
    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }

    private int _playerChances = 3;
    public int Chances
    {
        get
        {
            return _playerChances;
        }
        set
        {
            _playerChances = value;
        }
    }

    private int _score = 0;
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }

    private int _money = 100;
    public int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
        }
    }

    private float _damage = 50;
    public float Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }

    private float _regen = 1f;
    public float Regen
    {
        get
        {
            return _regen;
        }
        set
        {
            _regen = value;
        }
    }

    private float _healthRegenRate = 1f;
    public float HealthRegenRate
    {
        get
        {
            return _healthRegenRate;
        }
        set
        {
            _healthRegenRate = value;
        }
    }

    private float _speed = 10;
    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }

    public void Awake()
    {
        GameObject save = GameObject.FindGameObjectWithTag("SavedData");
        if(save!=null)
        {
            instance = this;
            instance.SetStats(DataManager.LoadPlayerStats());
            save.GetComponent<GameActualization>().playerStats = true;
        }
        else if(instance == null)
        {
            instance = this;
        }
        else
        {
            _currentHealth = _maxHealth;
        }
    }

    public void Respawn()
    {
        _currentHealth = _maxHealth;
    }

    private void SetStats(PlayerStatsMemory data)
    {
        _playerName = data.name;
        _maxHealth = data.maxHealth;
        _currentHealth = data.currentHealth;
        _playerChances = data.chances;
        _score = data.score;
        _money = data.money;
        _damage = data.damage;
        _regen = data.regen;
        _healthRegenRate = data.healthRegenRate;
        _speed = data.speed;
    }
}
