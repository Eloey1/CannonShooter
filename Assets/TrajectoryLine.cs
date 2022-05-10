using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private GameObject[] dots;

    [SerializeField] private int numberOfDots;
    [SerializeField] private float distanceBtwDots = 0.1f;
    [SerializeField] private float dotZPos; 

    void Start()
    {
        dots = new GameObject[numberOfDots];

        for (int i = 0; i < dots.Length; i++)
        {
            //dots[i] = Instantiate(dotPrefab, new Vector3(transform.position.x, transform.position.y, -2), transform.rotation);
            dots[i] = Instantiate(dotPrefab, new Vector3(transform.position.x, transform.position.y, dotZPos), transform.rotation);

        }
    }
    
    void Update()
    {
        Direction();
        //FaceMouse();

        if (CannonStats.Instance.shootForce != 0)
        {
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].transform.position = DotPosition(i * distanceBtwDots);
            }
        }
        else
        {
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].transform.position = new Vector3(transform.position.x, transform.position.y, dotZPos);
            }
        }
    }

    void FaceMouse()
    {
        transform.up = -CannonStats.Instance.rotation;
    }

    void Direction()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 cannonPos = transform.position;

        CannonStats.Instance.rotation = mousePos - cannonPos;
    }

    Vector2 DotPosition(float time)
    {
        Vector2 currentDotPos = (Vector2)transform.position + (-CannonStats.Instance.rotation.normalized * CannonStats.Instance.shootForce * time) + 0.5f * Physics2D.gravity * (time * time);
        
        return currentDotPos;
    }
}
