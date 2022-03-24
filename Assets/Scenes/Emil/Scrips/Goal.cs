using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    [SerializeField] bool goal = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("GOAL!!!");
            Destroy(collision.gameObject);
            goal = true;
        }
    }
}
