using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball") //N�r bollen kolliderar s�...
        {
            Destroy(collision.gameObject); //F�rflytta ist�llet f�r att ta bort h�r?

            //Eller skapa en ny boll i n�sta portal med motsvarande velocity
        }

        Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>(); //Kan nog anv�ndas f�r att hitta n�rmsta portal?
        //Nej f�r vi anv�nder kollisionens object...
    }
}
