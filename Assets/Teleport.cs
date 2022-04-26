using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject connectedPortal;
    public bool activePortal = true; //Kan man anv�nda annat �n public / [SerializeField] h�r?
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
            //�ndra s� positionen blir r�tt i f�rh�llande.

            if (changeDirection) //Skulle kunna ha en riktningsk�nslig variabel.
            {
                //�ndrar bollens riktning i x-led.
            }
            

            connectedScript.activePortal = false; //G�r s� bollen inte teleporterar direkt n�r den kommer till n�sta portal
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        activePortal = true; //Portalen kan anv�ndas igen n�r bollen l�mnat.
    }
}
