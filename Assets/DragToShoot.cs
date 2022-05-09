using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class DragToShoot : MonoBehaviour
{
    [Header("Shooting the Ball")]
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float shootForceMultiplier = 2;
    [SerializeField] float maxShootForce;
    [SerializeField] float minShootForce;
    //private float shootForce = CannonStats.Instance.shootForce;
    //public float ShootForce
    //{
    //    get { return shootForce; }
    //    set
    //    {
    //        if (value >= maxShootForce)
    //        {
    //            value = maxShootForce;
    //        }
    //        if (value <= minShootForce)
    //        {
    //            value = minShootForce;
    //        }

    //        shootForce = value;
    //    }
    //}//Sätt ett maxvärde på shooForce (kanske get; set;)
    private BoxCollider boxCollider;
    private float angle;
    private Touch touch;

    private Vector3 touchPosition, shootPointPos, mousePosition;
    private Vector2 faceDirection, cannonPos;
    private Quaternion shootPointRotation;

    private bool shoot = false, threadActive = false;

    private List<GameObject> circleList = new List<GameObject>();

    void Start()
    {
        SceneManager.LoadScene("Background", LoadSceneMode.Additive);

        boxCollider = GetComponent<BoxCollider>();
        shootPointPos = shootPoint.position;
        shootPointPos.z = -1;
        cannonPos = transform.position;
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            Debug.Log("funkar2");
            mousePosition.z = transform.position.z;

            if (boxCollider.bounds.Contains(mousePosition) && !threadActive)
            {
                Debug.Log("funkar");
                ThreadStart ts = new ThreadStart(CalculateShootForce);
                Thread thread = new Thread(ts);
                thread.Start();
            }

            transform.up = -CannonStats.Instance.rotation;
            //CannonStats.Instance.shootForce = ShootForce;
        }
        
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = transform.position.z;

            shootPointPos = shootPoint.position;
            shootPointPos.z = -1;

            shootPointRotation = shootPoint.rotation;

            if (boxCollider.bounds.Contains(touchPosition) && !threadActive)
            {
                ThreadStart ts = new ThreadStart(CalculateShootForce);
                Thread thread = new Thread(ts);
                thread.Start();
            }

            transform.up = -faceDirection;
            //CannonStats.Instance.shootForce = ShootForce;
        }

        if (shoot)
        {
            //Shoot(ShootForce);
            Shoot(CannonStats.Instance.shootForce);
        }
    }

    void CalculateShootForce()
    {
        while (touch.phase != TouchPhase.Ended || Input.GetMouseButton(0))
        {
            threadActive = true;
            //Avståndsformeln mellan kanonens position och fingrets position
            //ShootForce = Vector3.Distance(shootPointPos, touchPosition) * shootForceMultiplier;
            CannonStats.Instance.shootForce = Vector2.Distance(shootPointPos, mousePosition) * shootForceMultiplier;
            //Console.WriteLine(ShootForce);

            CannonRotation();
        }

        if (touch.phase == TouchPhase.Ended || Input.GetMouseButtonUp(0))
        {
            shoot = true;
            threadActive = false;
        }
    }

    void Shoot(float shootForce)
    {
        GameObject ball = Instantiate(ballPrefab, shootPointPos, shootPointRotation);
        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
        ballRb.AddForce(shootPoint.up * shootForce, ForceMode2D.Impulse);
        shoot = false;
    }
    void CannonRotation()
    {
        //faceDirection = (Vector2)touchPosition - cannonPos;
        CannonStats.Instance.rotation = (Vector2)mousePosition - cannonPos;

    }
}
