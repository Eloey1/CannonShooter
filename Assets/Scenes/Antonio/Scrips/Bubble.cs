using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    //ANTONIOS OCH EMILS SCRIPT
    
    [SerializeField] float speed;
    private bool movingUp = false;
    GameObject ball;
    Rigidbody2D ballRb;



    // Update is called once per frame
    void Update()
    {

        if (movingUp == true)
        {
            ball.transform.position += transform.up * speed * Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Ball")
        {
            collision.transform.position = transform.position;
            this.transform.parent = collision.transform;
            ball = collision.gameObject;

            ballRb = collision.GetComponent<Rigidbody2D>();
            ballRb.gravityScale = 0;
            ballRb.velocity = Vector2.zero;
            movingUp = true;

        }
        if (collision.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
            ballRb.gravityScale = 1;
        }
        if (collision.gameObject.tag == "Bubble")
        {
            Destroy(gameObject);
            //ballRb.gravityScale = 1;
            ballRb.AddForce(Vector3.up * speed, ForceMode2D.Impulse);
            
        }

    }

}
