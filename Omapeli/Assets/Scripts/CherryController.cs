using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CherryController : MonoBehaviour
{
    [SerializeField] private Text cherriesText;
    private int cherries = 0;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;
        }
    }
}
