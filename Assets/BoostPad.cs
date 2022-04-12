using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour
{

    [SerializeField]private float boostForce;
    

    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GameObject ball = GameObject.FindGameObjectWithTag("Ball");
            Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
            ballRb.AddForce(ballRb.velocity * boostForce);
        }
    }
}
