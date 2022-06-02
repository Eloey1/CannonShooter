using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchErrorMessage : MonoBehaviour
{
    // Skript skapat av: Emil, Antonio


    [SerializeField] private GameObject errorTextPrefab;
    private BoxCollider cannonHitbox;
    private Touch touch;
   
    private Vector3 touchPosition;
    private Vector3 mousePos;
    
    private bool errorMouse = false;
    private bool errorTouch = false;
    private bool touching = false;

    void Start()
    {
        cannonHitbox = GetComponent<BoxCollider>();
    }


    void Update()
    {
        ErrorInputs();
        ErrorChecks();
    }

    // Här kollar om musenpekaren eller om du använder moblien och gör så error meddelandet ska skrivat ut eller inte.
    void ErrorInputs()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = transform.position.z;

            
            if (CannonStats.Instance.threadActive)
            {
                errorTouch = false;
                
            }
            else if (!CannonStats.Instance.threadActive && touching)
            {
                errorTouch = true;
                touching = true;
            }
        }


        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = transform.position.z;

            if (Input.GetMouseButtonDown(0) && cannonHitbox.bounds.Contains(mousePos))
            {
                errorMouse = false;
            }
            else
            {
                errorMouse = true;
            }
        }
    }

    // Här kollar den mest att texten inte är null och om vi har vunnit/förlorat så ska den inte gå att få error meddelande.
    void ErrorChecks()
    {
        if (!cannonHitbox.bounds.Contains(touchPosition) && Input.touchCount > 0 && errorTouch)
        {
            if (errorTextPrefab != null)
            {
                if (!CannonStats.Instance.win)
                {
                    if (!CannonStats.Instance.lose)
                    {
                        GameObject prefab = Instantiate(errorTextPrefab, new Vector3(touchPosition.x, touchPosition.y, 0), errorTextPrefab.transform.rotation);
                        Destroy(prefab, 2);
                    }
                }
            }
        }

        else if (!cannonHitbox.bounds.Contains(mousePos) && Input.GetMouseButtonDown(0) && errorMouse)
        {
            if (errorTextPrefab != null)
            {
                if (!CannonStats.Instance.win)
                {
                    if (!CannonStats.Instance.lose)
                    {
                        GameObject prefab = Instantiate(errorTextPrefab, new Vector3(mousePos.x, mousePos.y, 0), errorTextPrefab.transform.rotation);
                        Destroy(prefab, 2);
                    }
                }
            }
        }
    }
}
