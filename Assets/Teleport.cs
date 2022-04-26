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
        if (collision.gameObject.tag == "Ball") //När bollen kolliderar så...
        {
            Destroy(collision.gameObject); //Förflytta istället för att ta bort här?

            //Eller skapa en ny boll i nästa portal med motsvarande velocity
        }

        Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>(); //Kan nog användas för att hitta närmsta portal?
        //Nej för vi använder kollisionens object...
    }
}
