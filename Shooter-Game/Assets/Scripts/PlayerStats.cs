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
        if(instance == null)
        {
            instance = this;
        }
        _currentHealth = _maxHealth;
    }

    public void Respawn()
    {
        _currentHealth = _maxHealth;
    }
}
