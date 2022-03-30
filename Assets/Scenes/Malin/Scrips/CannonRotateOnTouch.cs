using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotateOnTouch : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float rotationSpeed;
    [SerializeField] float offset;
    private BoxCollider collider;
    private float angle;
    void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;

            if (!collider.bounds.Contains(touchPosition))
            {
                CannonRotation(touchPosition);
            }

            //transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(touchPosition.x, touchPosition.y, touchPosition.z, 0), rotationSpeed * Time.deltaTime);

            //transform.rotation.z = Vector3.MoveTowards(new Vector3(0, 0, transform.rotation.z), touchPosition, rotationSpeed);
        }
    }
    void CannonRotation(Vector3 touchPos)
    {
        Vector2 weaponDir = touchPos - transform.position;
        angle = Mathf.Atan2(weaponDir.y, weaponDir.x) * Mathf.Rad2Deg + offset;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
