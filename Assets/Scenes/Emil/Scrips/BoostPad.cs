using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour
{

    [SerializeField]private float boostForce;
    

    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision) // Allt som kolliderar får en Boost
    {
        //if (collision.gameObject.tag == "Ball")
        //{
        //    Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
        //    ballRb.AddForce(ballRb.velocity * boostForce);
        //}

        Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
        ballRb.AddForce(ballRb.velocity * boostForce);
    }
}
