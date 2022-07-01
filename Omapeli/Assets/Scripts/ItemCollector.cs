using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text cherriesText, diamondsText;
    private int cherries = 0;
    private int diamonds;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;
        }
        
        if (collision.gameObject.CompareTag("Diamond"))
        {
            Destroy(collision.gameObject);
            diamonds = diamonds +1;
            diamondsText.text = "Diamonds: " + diamonds;
        }

    }
}
