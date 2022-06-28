using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondController : MonoBehaviour
{
    [SerializeField] private Text diamondsText;
    private int diamonds;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            diamonds = diamonds + 1;
            diamondsText.text = "Diamonds: " + diamonds;
        }
    }
}
