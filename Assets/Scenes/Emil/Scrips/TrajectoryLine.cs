using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    // Skript skapat av: Emil


    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private GameObject[] dots;

    [SerializeField] private int numberOfDots;
    [SerializeField] private float distanceBtwDots = 0.1f;
    private float dotZPos; 

    // Skapar alla prikar när spelet startas.
    void Start()
    {
        dots = new GameObject[numberOfDots];

        for (int i = 0; i < dots.Length; i++)
        {
            dots[i] = Instantiate(dotPrefab, new Vector3(transform.position.x, transform.position.y, dotZPos), transform.rotation);
        }
    }
    
    void Update()
    {
        if (!CannonStats.Instance.cannonActive || !CannonStats.Instance.threadActive)
        {
            return;
        }

        Direction();
        DotsPositionUpdate();
    }

    // Detta kallas på i Update() för att prickarna ska veta vilken position de ska ha varje frame.
    void DotsPositionUpdate()
    {
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

    // Direktionen trajecory linan ska riktas åt.
    void Direction()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 cannonPos = transform.position;

        if (Input.GetMouseButton(0))
        {
            CannonStats.Instance.rotation = mousePos - cannonPos;
        }
    }

    // Räknar ut positionerna till prickarna för trajectory linan. 
    Vector2 DotPosition(float time)
    {
        Vector2 currentDotPos = (Vector2)transform.position + (-CannonStats.Instance.rotation.normalized * CannonStats.Instance.shootForce * time) + 0.5f * Physics2D.gravity * (time * time);
        
        return currentDotPos;
    }
}
