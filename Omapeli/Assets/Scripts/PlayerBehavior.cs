using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakeDmg(20);
            Debug.Log(GameManager.gameManager._playerHealth.PlayerHealth);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerHeal(10);
            Debug.Log(GameManager.gameManager._playerHealth.PlayerHealth);

        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.dmgUnit(dmg);

    }

    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.healUnit(healing);

    }
}
