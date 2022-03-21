using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotate : MonoBehaviour
{

    [SerializeField] float rotateSpeed;
    [SerializeField] Vector3 rotateDirection;

    void Start()
    {
        
    }

    
    void Update()
    {
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
