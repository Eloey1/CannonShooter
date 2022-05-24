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
    [SerializeField] GameObject fingerTex;
    [SerializeField] float shootForceMultiplier = 2;
    [SerializeField] float maxShootForce = 15;
    [SerializeField] float minShootForce = 3;
    private float shootForce = CannonStats.Instance.shootForce;
    private float timeLeft = 5f;
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
    }
    private BoxCollider boxCollider;
    private float angle;
    private Touch touch;
    bool mouseClicked;

    private Vector3 touchPosition, shootPointPos, mousePosition;
    private Vector2 faceDirection, cannonPos;
    private Quaternion shootPointRotation;

    private bool shoot = false, threadActive = false;

    void Start()
    {
        SceneManager.LoadScene("Background", LoadSceneMode.Additive);

        boxCollider = GetComponent<BoxCollider>();
        shootPointPos = shootPoint.position;
        shootPointPos.z = -1;
        cannonPos = transform.position;

        CannonStats.Instance.cannonActive = true;

    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Instantiate(fingerTex, new Vector3(cannonPos.x + 0.7f, cannonPos.y - 1f, -2), new Quaternion(0, 0, 0, 0));
            timeLeft = 3f;
        }

        if (!CannonStats.Instance.cannonActive)
        {
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseClicked = false;
        }

        if (Input.GetMouseButton(0))
        {
            mouseClicked = Input.GetMouseButton(0);

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;

            if (Input.GetMouseButtonDown(0) && boxCollider.bounds.Contains(mousePosition) && !threadActive)
            {
                timeLeft = 15f;

                ThreadStart ts = new ThreadStart(CalculateShootForceMouse);
                Thread thread = new Thread(ts);
                thread.Start();
            }

            if (threadActive)
            {

                shootPointPos = shootPoint.position;
                shootPointPos.z = -1;

                transform.up = -CannonStats.Instance.rotation;
                CannonStats.Instance.shootForce = ShootForce;
            }
        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = transform.position.z;

            if (touch.phase == TouchPhase.Began && boxCollider.bounds.Contains(touchPosition) && !threadActive)
            {
                timeLeft = 15f;

                ThreadStart ts = new ThreadStart(CalculateShootForce);
                Thread thread = new Thread(ts);
                thread.Start();

                Debug.Log(thread.ToString());
            }

            if (threadActive)
            {
                shootPointPos = shootPoint.position;
                shootPointPos.z = -1;

                shootPointRotation = shootPoint.rotation;

                transform.up = -CannonStats.Instance.rotation;
                CannonStats.Instance.shootForce = ShootForce;
            }

        }

        if (shoot)
        {
            if (CannonStats.Instance.ballAmount != 0)
            {
                Shoot(CannonStats.Instance.shootForce);
            }
        }
    }

    void CalculateShootForceMouse()
    {
        while (mouseClicked)
        {
            threadActive = true;
            CannonStats.Instance.threadActive = true;
            ShootForce = Vector2.Distance(shootPointPos, mousePosition) * shootForceMultiplier;

            CannonRotation();
        }

        shoot = true;
        threadActive = false;
        CannonStats.Instance.threadActive = false;
    }

    void CalculateShootForce()
    {
        while (touch.phase != TouchPhase.Ended || mouseClicked)
        {
            threadActive = true;
            ShootForce = Vector2.Distance(shootPointPos, mousePosition) * shootForceMultiplier;

            CannonRotation();
        }

        shoot = true;
        threadActive = false;
    }

    void Shoot(float shootForce)
    {
        GameObject ball = Instantiate(ballPrefab, shootPointPos, shootPointRotation);
        CannonStats.Instance.ball = ball;

        CannonStats.Instance.ballAmount -= 1;

        Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
        CannonStats.Instance.ballRb = ballRb;

        ballRb.AddForce(shootPoint.up * shootForce, ForceMode2D.Impulse);
        shoot = false;
    }
    void CannonRotation()
    {
        //faceDirection = (Vector2)touchPosition - cannonPos;
        CannonStats.Instance.rotation = (Vector2)mousePosition - cannonPos;

    }
}
