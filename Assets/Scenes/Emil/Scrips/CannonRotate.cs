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
        // Roterar �t h�ger n�r man klickar p� h�ger pilknapp samma med v�nster
        
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
