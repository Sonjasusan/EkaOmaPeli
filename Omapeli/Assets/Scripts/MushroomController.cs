using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.dmgUnit(dmg);

    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            PlayerTakeDmg(5); //Player saa damagea kun osuu
            Debug.Log(GameManager.gameManager._playerHealth.PlayerHealth);
        }
    }
}
