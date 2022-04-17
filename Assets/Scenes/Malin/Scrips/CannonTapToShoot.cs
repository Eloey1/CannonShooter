using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CannonTapToShoot : MonoBehaviour
{
    [Header("Shooting the Ball")]
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float shootForce;
    private BoxCollider boxCollider;
    [SerializeField] Button button;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        //button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;

            //transform.position = touchPosition;

            //touch.phase == TouchPhase.Began

            //if (touch.phase == TouchPhase.Began)
            //{
            //    button.onClick.AddListener(Shoot);
            //}

            //if(Vector2.Distance((Vector2)transform.position, touch.position) <= 200)
            //{
            //    Shoot();
            //}

            if (boxCollider.bounds.Contains(touchPosition) && touch.phase == TouchPhase.Began)
            {
                Shoot();
            }
        }


    }

    void Shoot()
    {
        GameObject ball = Instantiate(ballPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
        ballRb.AddForce(shootPoint.up * shootForce, ForceMode2D.Impulse);
    }
}
