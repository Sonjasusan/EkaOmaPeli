using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text cherriesText;
    [SerializeField] private Text diamondsText;
    private int cherries;
    private int diamonds;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries = cherries + 1;
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
