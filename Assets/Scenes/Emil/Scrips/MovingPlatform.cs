using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Skript skapat av: Emil, Antonio

    [SerializeField] private float speed;
    [SerializeField] private int startingPoint;
    [SerializeField] private Transform[] points;

    private int index; // Indexet av arrayen

    void Start()
    {
        transform.position = points[startingPoint].position; // Vilken point platfomen startat p�
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, points[index].position) < 0.2)
        {
            index++;
            if (index == points.Length)
            {
                index = 0; 
            }
        }

        // H�r g�r vi s� platformen ska r�ra sig
        transform.position = Vector2.MoveTowards(transform.position, points[index].position, speed * Time.deltaTime);
    }
}
