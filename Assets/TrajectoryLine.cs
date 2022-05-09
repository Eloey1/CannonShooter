using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    private Vector2 direction;

    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private GameObject[] dots;

    [SerializeField] private int numberOfDots;
    [SerializeField] private float distanceBtwDots = 0.1f;
    private float force;

    void Start()
    {
        dots = new GameObject[numberOfDots];
        //force = FindObjectOfType<CannonShoot>().shootForce;

        for (int i = 0; i < dots.Length; i++)
        {
            //dots[i] = Instantiate(dotPrefab, new Vector3(transform.position.x, transform.position.y, -2), transform.rotation);
            dots[i] = Instantiate(dotPrefab, new Vector3(transform.position.x, transform.position.y, -2), transform.rotation);

        }
    }
    
    void Update()
    {
        force = CannonStats.Instance.shootForce;

        Direction();
        //FaceMouse();

        for (int i = 0; i < dots.Length; i++)
        {
            dots[i].transform.position = DotPosition(i * distanceBtwDots);
        }

    }

    void FaceMouse()
    {
        transform.up = direction;
    }

    void Direction()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 cannonPos = transform.position;

        // = mousePos - cannonPos;
        direction = CannonStats.Instance.rotation;
    }

    Vector2 DotPosition(float time)
    {
        Vector2 currentDotPos = (Vector2)transform.position + (direction.normalized * force * time) + 0.5f * Physics2D.gravity * (time * time);
        
        return currentDotPos;
    }
}
