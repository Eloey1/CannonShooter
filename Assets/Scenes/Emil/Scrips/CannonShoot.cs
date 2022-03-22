using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [Header("Shooting the Ball")]
    [SerializeField]Transform shootPoint;
    [SerializeField]GameObject ballPrefab;
    [SerializeField] float shootForce;

    //GameObject ball;
    //Rigidbody2D ballRb;

    void Start()
    {
        //ballRb = ball.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject ball = Instantiate(ballPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
        ballRb.AddForce(shootPoint.up * shootForce, ForceMode2D.Impulse);
    }
}
