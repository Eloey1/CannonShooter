using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWhenCollide : MonoBehaviour
{
    [SerializeField] GameObject particlePrefab;
    private void Update()
    {
        //OnTriggerBreak2D(GetComponent<BoxCollider2D>());
    }
    //private void OnTriggerBreak2D(Collider2D collision)
    //{
    //    on

    //    if (collision.gameObject.tag == "Ball")
    //    {
    //        Debug.Log("Break plank");
    //        Destroy(this);
    //        //goal = true;
    //    }
    //    if (collision.gameObject.tag == "Ball")
    //    {
    //        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
    //        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
    //        ballRb.AddForce(ballRb.velocity * boostForce);
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Break plank");
            Destroy(gameObject);
            Instantiate(particlePrefab, this.transform.position, this.transform.rotation);
            //goal = true;
        }
    }
}
