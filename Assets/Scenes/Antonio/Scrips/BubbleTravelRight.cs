using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTravelRight : MonoBehaviour
{
    //ANTONIOS OCH EMILS SCRIPT

    [SerializeField] float speed;
    private bool movingRight = false;
    GameObject ball;
    Rigidbody2D ballRb;



    // Update is called once per frame
    void Update()
    {

        if (movingRight == true)
        {
            //ball.transform.position += transform.right * speed * Time.deltaTime;

            ball.transform.position += Vector3.right * speed * Time.deltaTime;
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
            movingRight = true;

        }
        if (collision.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
            ballRb.gravityScale = 1;
        }

    }

}
