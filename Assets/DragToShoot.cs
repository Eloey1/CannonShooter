using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class DragToShoot : MonoBehaviour
{
    [Header("Shooting the Ball")]
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject ballPrefab, circlePrefab;
    [SerializeField] float shootForceMultiplier;
    private float shootForce; //Sätt ett maxvärde på shooForce (kanske get; set;)
    private BoxCollider boxCollider;
    [SerializeField] float rotationSpeed;
    [SerializeField] float offset = 90;
    private float angle;
    private Touch touch;

    private Vector3 touchPosition, shootPointPos;
    private Quaternion shootPointRotation, cannonRotation;

    private bool shoot = false, threadActive = false;

    private List<GameObject> circleList = new List<GameObject>();

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        shootPointPos = shootPoint.position;
        shootPointPos.z = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = -1f;

            shootPointPos = shootPoint.position;
            shootPointPos.z = -1;

            shootPointRotation = shootPoint.rotation;

            if (touch.phase == TouchPhase.Began)
            {
                circleList.Add(Instantiate(circlePrefab, shootPointPos - touchPosition, shootPointRotation));
            }

            if (boxCollider.bounds.Contains(touchPosition))
            {
                ThreadStart ts = new ThreadStart(CalculateShootForce);
                Thread thread = new Thread(ts);
                thread.Start();
            }
            transform.rotation = cannonRotation;

            if (threadActive)
            {
                Indicator();
            }
        }

        if(Input.touchCount == 0)
        {
            foreach(GameObject g in circleList)
            {
                Destroy(g);
            }
        }

        if (shoot)
        {
            Shoot(shootForce);
        }
    }
    void Indicator()
    {
        ///Skapa linjen för hur bollen skjuts
        ///Kanske skapa en boll i kanonens riktning med avstånd genom shootForce?
        ///
        //if(touch.phase == TouchPhase.Began)
        //{
        //    circleList.Add(Instantiate(circlePrefab, shootPointPos - touchPosition, shootPointRotation));
        //}

        for (int i = 0; i < circleList.Count; i++)
        {
            circleList[i].transform.position = boxCollider.center - touchPosition;
        }

        

    }

    void CalculateShootForce()
    {
        while(touch.phase != TouchPhase.Ended)
        {
            threadActive = true;
            //Avståndsformeln mellan kanonens position och fingrets position
            shootForce = Vector3.Distance(shootPointPos, touchPosition) * shootForceMultiplier;
            Console.WriteLine(shootForce);

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
    //void CannonRotation(Vector3 touchPos)
    //{
    //    //Uträkning för riktningen mellan kanonens position och fingrets position.
    //    Vector2 weaponDir = touchPos - transform.position;
    //    angle = Mathf.Atan2(weaponDir.y, weaponDir.x) * Mathf.Rad2Deg + offset;
    //    transform.rotation = Quaternion.Euler(0, 0, angle);
    //}
    void CannonRotation()
    {
        //Uträkning för riktningen mellan kanonens position och fingrets position.
        angle = Mathf.Atan2(touchPosition.y, touchPosition.x) * Mathf.Rad2Deg + offset;
        cannonRotation = Quaternion.Euler(0, 0, angle);
    }
}
