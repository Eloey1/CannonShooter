using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    // Skript skapat av: Emil

    [Header("Shooting the Ball")]
    [SerializeField]Transform shootPoint;
    [SerializeField]GameObject ballPrefab;
    [SerializeField]public float shootForce;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // en ny boll blir till den nya instansierade bollen och hämtar rigidbodyn av den för att kunna ge den kraft
        
        GameObject ball = Instantiate(ballPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
        //ballRb.AddForce(shootPoint.up * shootForce, ForceMode2D.Impulse);
        ballRb.velocity = transform.up * shootForce;
    }
}
