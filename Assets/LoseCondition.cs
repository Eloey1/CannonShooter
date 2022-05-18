using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    [SerializeField] private int amountOfBalls;
    [SerializeField] private float maxWidth = 10;
    [SerializeField] private float maxHeight = 20;
    
    private Vector2 ballPos;
    private bool inCamera = true;

    void Start()
    {
        CannonStats.Instance.ballAmount = amountOfBalls;
    }

    
    void Update()
    {
        CheckBounds();

        // måste göra ett nytt condition där vi förlorar när bollen står still.
        
        if (CannonStats.Instance.ballAmount == 0 && !inCamera)
        {
            CannonStats.Instance.lose = true;
            Debug.Log("You Lost!!!!!!!");
        }

        //Debug.Log("inCamera: " + inCamera);
        //Debug.Log("Lose: " + CannonStats.Instance.lose);
    }

    void CheckBounds()
    {
        if (CannonStats.Instance.ball != null)
        {
            if (CannonStats.Instance.ball.transform.position.x > maxWidth || CannonStats.Instance.ball.transform.position.x < -maxWidth)
            {
                inCamera = false;
            }
            else
            {
                inCamera = true;
            }

            if (CannonStats.Instance.ball.transform.position.y < -maxHeight)
            {
                inCamera = false;
            }
            else
            {
                inCamera = true;
            }
        }
    }
}
