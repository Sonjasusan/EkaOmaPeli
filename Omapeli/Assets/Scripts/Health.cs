using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    //Fields
    int _currentHealth;
    int _currentMaxHealth;

    //Prop
    public int PlayerHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }
    
    public int PlayerMaxHealth
    {
        get { return _currentMaxHealth; }
        set { _currentMaxHealth = value; }
    }

    public Health(int playerHealth, int playerMaxHealth)
    {
        _currentHealth = playerHealth;
        _currentMaxHealth = playerMaxHealth;
    }

    //Metodit

    public void dmgUnit(int dmgAmount) //<--Damage
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= dmgAmount;
        }
    }
    
    public void healUnit(int healAmount) //<--Heal
    {
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healAmount;
        }
        if (_currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }


}
