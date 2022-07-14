using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using Assets.Scripts;

public class PlayerController : MonoBehaviour
{
    //public float speed;
    public float jumpForce; //Hyppimistoiminto
   //public GameObject winTextObject;

    private float horizontalInput;
    private float walkSpeed = 3f;
    private float runSpeed = 1.5f;

    private bool runInput; //Juoksun nappi -> s



    public Animator animator; //Liikehdinnän animointia varten

    private bool isGrounded; //Tarkistetaan onko pelaaja maassa
    public Rigidbody2D rb;
    //private Vector2 movementDir; //Liikkumistoiminto
    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        //Haetaan komponentti
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //movementDir.x = Input.GetAxis("Horizontal") * speed; //a & d  & nuoli-napit

        horizontalInput = Input.GetAxis("Horizontal"); //Kävely
        runInput = Input.GetButton("Run");//Juoksu



        //movementDir.y = rb.velocity.y;

        //var animSpeed = horizontalInput;
        var animSpeed = horizontalInput * (runInput ? 2 : 1);
        animator.SetFloat(Keys.ANIMATION_SPEED_KEY, Mathf.Abs(animSpeed));
        //Aiemmat animaatio käsittelijät
        //animator.SetFloat("Speed", movementDir.x = Input.GetAxis("Horizontal"));
        //animator.SetFloat("Speed", speed);

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
            jumpSoundEffect.Play();
            
        }

        //Juoksu
        animator.SetFloat(Keys.ANIMATION_SPEED_KEY, Mathf.Abs(animSpeed));
    }
    private void FixedUpdate()
    {
        //rb.velocity = movementDir;

        var velocity = rb.velocity;
        var moveSpeed = 0f;
        var moveDirection = 1f;

        if (!Mathf.Approximately(horizontalInput, 0))
        {
            moveSpeed = walkSpeed; //Liikkumisnopeus on kävelynopeus
            moveDirection = Mathf.Sign(horizontalInput);
        }
        
        velocity.x = moveSpeed * moveDirection;
        rb.velocity = velocity;

        //Juoksun if
        if (!Mathf.Approximately(horizontalInput, 0))
        {
            moveSpeed = runInput ? runSpeed : walkSpeed;
            moveDirection = Mathf.Sign(horizontalInput);
        }
    }


    public void gameover() /*<- kun gameover tulee*/
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

