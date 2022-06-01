using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchErrorMessage : MonoBehaviour
{

    [SerializeField] private GameObject errorTextPrefab;
    private BoxCollider cannonHitbox;
    private Touch touch;
    private Vector3 touchPosition;
    private Vector3 mousePos;
    private bool dragFromCannon = false;
    private bool error = false;

    void Start()
    {
        cannonHitbox = GetComponent<BoxCollider>();
    }


    void Update()
    {

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = transform.position.z;

            if (touch.phase == TouchPhase.Began && cannonHitbox.bounds.Contains(touchPosition))
            {
                error = false;
            }
            else
            {
                error = true;
            }
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            dragFromCannon = false;
        }

        if (Input.GetMouseButton(0))
        {
            dragFromCannon = Input.GetMouseButton(0);
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = transform.position.z;

            if (Input.GetMouseButtonDown(0) && cannonHitbox.bounds.Contains(mousePos))
            {
                Debug.Log("in cannon");
                error = false;
            }
            else
            {
                error = true;
            }
        }



        if (!cannonHitbox.bounds.Contains(touchPosition) && Input.touchCount > 0 && error)
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
        else if (!cannonHitbox.bounds.Contains(mousePos) && Input.GetMouseButtonDown(0) && error)
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
