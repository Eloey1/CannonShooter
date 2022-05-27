using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Skript skapat av: Emil och Malin

    
    [SerializeField] private GameObject particleEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            // Förstör bollen om den träffar triggren i målet,  
            Destroy(collision.gameObject);
            
            SceneManager.LoadScene("BetweenLevels", LoadSceneMode.Additive);
            
            CannonStats.Instance.win = true;
            CannonStats.Instance.cannonActive = false;

            if (particleEffect != null)
            {
                Instantiate(particleEffect, transform.position, transform.rotation);
            }
        }
    }
}
