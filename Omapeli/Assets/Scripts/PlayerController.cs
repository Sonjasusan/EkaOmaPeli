using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce; //Hyppimistoiminto
    //public TextMeshProUGUI countText; //teksti
    //public GameObject winTextObject;

    private bool isGrounded; //Tarkistetaan onko pelaaja maassa
    public Rigidbody2D rb; //raahataan rigidbody scripti kohdan rb-kohtaan
    private Vector2 movementDir; //Liikkumistoiminto
 

    // Start is called before the first frame update
    void Start()
    {
        //Haetaan komponentti
        rb = GetComponent<Rigidbody2D>();
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
}
