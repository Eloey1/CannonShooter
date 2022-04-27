using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class DragToShoot : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Shooting the Ball")]
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float shootForce;
    private BoxCollider boxCollider;
    [SerializeField] float rotationSpeed;
    [SerializeField] float offset = 90;
    private float angle;
    private Touch touch;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = -1f;

            if (!boxCollider.bounds.Contains(touchPosition))
            {
                CannonRotation(touchPosition);

                ThreadStart ts = new ThreadStart(CalculateShootForce);
                Thread thread = new Thread(ts);
                thread.Start();

                //CalculateShootForce(touch);
            }

            if(touch.phase == TouchPhase.Ended)
            {
                Shoot(shootForce);
            }
            

        }
    }

    void CalculateShootForce() //Tråd för den här?
    {
        while(touch.phase != TouchPhase.Ended)
        {
            //Avståndsformeln mellan kanonens position och fingrets position
            shootForce = Vector2.Distance(shootPoint.position, touch.position) / 10;
            Console.WriteLine(shootForce);
        }

        Thread.CurrentThread.Join();
    }

    void Shoot(float shootForce)
    {
        GameObject ball = Instantiate(ballPrefab, new Vector3(shootPoint.position.x, shootPoint.position.y, 0), shootPoint.rotation);
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
        ballRb.AddForce(shootPoint.up * shootForce, ForceMode2D.Impulse);
    }
    void CannonRotation(Vector3 touchPos)
    {
        //Uträkning för riktningen mellan kanonens position och fingrets position.
        Vector2 weaponDir = touchPos - transform.position;
        angle = Mathf.Atan2(weaponDir.y, weaponDir.x) * Mathf.Rad2Deg + offset;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
