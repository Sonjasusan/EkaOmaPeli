//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Cherry : MonoBehaviour
//{

//    public float speed;
//    public float rotationSpeed;
//    private Rigidbody2D rb;

//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        rb.velocity = Vector3.down * speed;
//        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime); //K‰‰ntyvyys
//    }
//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.GetComponent<PlayerController>())
//        {
//            collision.gameObject.GetComponent<PlayerController>().GameOver();
//        }

//        Destroy(this.gameObject);
//    }
    
    
//}
