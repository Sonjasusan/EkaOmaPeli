using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour //Kotkan "hyökkäys" 
{
    public float speed = 3f;
    private Transform target;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float fly = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, fly); 
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<PlayerBehavior>().UpdateHealth(-attackDamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }
}
