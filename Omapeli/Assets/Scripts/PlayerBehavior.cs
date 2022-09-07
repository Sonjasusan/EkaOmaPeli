using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] HealthBar  _healthbar;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Damagea hyppimisestä
        {
            PlayerTakeDmg(20); // Saa 20 damagea
            Debug.Log(GameManager.gameManager._playerHealth.PlayerHealth);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) //Voidaan healata shiftillä
        {
            PlayerHeal(10); //healaa kerralla 10
            Debug.Log(GameManager.gameManager._playerHealth.PlayerHealth);

        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.dmgUnit(dmg);
        _healthbar.SetHealth(GameManager.gameManager._playerHealth.PlayerHealth);

    }

    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.healUnit(healing);
        _healthbar.SetHealth(GameManager.gameManager._playerHealth.PlayerHealth);


    }
}
