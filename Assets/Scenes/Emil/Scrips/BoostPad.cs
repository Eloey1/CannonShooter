using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour
{
    // Skript skapat av: Emil, Antonio och Malin


    [SerializeField]private float boostForce;
    
    private void OnCollisionExit2D(Collision2D collision) // Allt som kolliderar får en Boost
    {
        Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
        ballRb.AddForce(ballRb.velocity * boostForce);
    }
}
