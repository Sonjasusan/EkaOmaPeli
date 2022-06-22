using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce; //Hyppimistoiminto
    public TextMeshProUGUI countText; //teksti
    public GameObject winTextObject;

    private bool isGrounded; //Tarkistetaan onko pelaaja maassa
    public Rigidbody2D rb; //raahataan rigidbody scripti kohdan rb-kohtaan
    private int count; //Laskuri "syödyille"/napatuille asioille
    private Vector2 movementDir; //Liikkumistoiminto

    // Start is called before the first frame update
    void Start()
    {
        //Haetaan komponentti
        rb = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    //Asetetaan laskuriteksti
    void SetCountText()
    {
        countText.text = "Items eated or found: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        movementDir.x = Input.GetAxis("Horizontal") * speed; //a & d -napit
        movementDir.y = rb.velocity.y;

        if (rb.velocity.y > -0.05 && rb.velocity.y < 0.05) //Onko pelaaja maassa
        {
            isGrounded = true; //On maassa
        }
        else
        {
            isGrounded = false; //Ei ole maassa
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = movementDir;
    }
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Syötävien ja esineiden ketäily 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

    }

    ////Osutaan kirsikkaan (syödään se)
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //Jos törmätään
    //    if (collision.gameObject.CompareTag("Cherry"))
    //    {
    //        Destroy(collision.gameObject); //Tuhotaan objekti mihin törmätään
    //    }
    //}
}
