using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject connectedPortal;
    public bool activePortal = true; //Kan man använda annat än public / [SerializeField] här?
    [SerializeField] bool changeDirection;
    private Teleport connectedScript;

    private void Start()
    {
        connectedScript = connectedPortal.GetComponent<Teleport>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball" && activePortal)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().position = connectedPortal.GetComponent<Transform>().position;
            //Ändra så positionen blir rätt i förhållande.

            if (changeDirection) //Skulle kunna ha en riktningskänslig variabel.
            {
                //Ändrar bollens riktning i x-led.
            }
            

            connectedScript.activePortal = false; //Gör så bollen inte teleporterar direkt när den kommer till nästa portal
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        activePortal = true; //Portalen kan användas igen när bollen lämnat.
    }
}
