using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnlyWithStone : MonoBehaviour
{
    // Skript skapat av: Antonio


    [SerializeField] GameObject crackedStoneParticle;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Om stenen kolliderar med "cracked stone", förstörs cracked stone
        if(collision.gameObject.tag == "Stone")
        {
            Destroy(gameObject);

            //När de kolliderar, startar partikeleffekten 
            if (crackedStoneParticle != null)
            {
                Instantiate(crackedStoneParticle, this.transform.position, this.transform.rotation);
            }
        }
    }
}
