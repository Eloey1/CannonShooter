using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWhenCollide : MonoBehaviour
{
    // Skript skapat av: Antonio


    [SerializeField] GameObject particlePrefab;
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        { 
            Destroy(gameObject);
            
            if (particlePrefab != null)
            {
                Instantiate(particlePrefab, this.transform.position, this.transform.rotation);
            }
        }
    }
}
