using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class DragToShoot : MonoBehaviour
{
    [Header("Shooting the Ball")]
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float shootForceMultiplier;
    [SerializeField] float maxShootForce;
    [SerializeField] float minShootForce;
    private float shootForce = CannonStats.Instance.shootForce;
    public float ShootForce
    {
        get { return shootForce; }
        set
        {
            if (value >= maxShootForce)
            {
                value = maxShootForce;
            }
            if (value <= minShootForce)
            {
                value = minShootForce;
            }

            shootForce = value;
        }
    }//S�tt ett maxv�rde p� shooForce (kanske get; set;)
    private BoxCollider boxCollider;
    private float angle;
    private Touch touch;

    private Vector3 touchPosition, shootPointPos;
    private Vector2 faceDirection = CannonStats.Instance.rotation, cannonPos;
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
            CannonStats.Instance.shootForce = ShootForce;
        }

        if (shoot)
        {
            Shoot(ShootForce);
        }
    }

    void CalculateShootForce()
    {
        while (touch.phase != TouchPhase.Ended)
        {
            threadActive = true;
            //Avst�ndsformeln mellan kanonens position och fingrets position
            ShootForce = Vector3.Distance(shootPointPos, touchPosition) * shootForceMultiplier;
            Console.WriteLine(ShootForce);

            CannonRotation();
        }

        if (touch.phase == TouchPhase.Ended)
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
        faceDirection = (Vector2)touchPosition - cannonPos;
    }
}
