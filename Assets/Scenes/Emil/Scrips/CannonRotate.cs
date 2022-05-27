using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotate : MonoBehaviour
{
    // Skript skapat av: Emil


    [SerializeField] float rotateSpeed;
    private Vector3 rotateDirection = new Vector3(0, 0, 1);

    
    void Update()
    {
        // Roterar åt höger när man klickar på höger pilknapp samma med vänster
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-rotateDirection * rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(rotateDirection * rotateSpeed * Time.deltaTime);
        }
    }
}
