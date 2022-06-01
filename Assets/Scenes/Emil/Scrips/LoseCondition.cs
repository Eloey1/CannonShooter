using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    // Skript skapat av: Emil, Antonio


    [SerializeField] private int amountOfBalls;
    [SerializeField] private float maxWidth = 10;
    [SerializeField] private float maxHeight = 20;
    [SerializeField] private float timeValue = 5;
    
    private bool inCamera = true;

    void Start()
    {
        CannonStats.Instance.ballAmount = amountOfBalls;
    }

    
    void Update()
    {
        if (CannonStats.Instance.win == false)
        {
            CheckBounds();
            TimerAfterLastBall();
        }


        if (CannonStats.Instance.ballAmount == 0 && !inCamera)
        {
            CannonStats.Instance.lose = true;
            Debug.Log("You Lost!");
        }
    }

    // Kollar om den sista bollen �r tillr�kligt l�ngt ut fr�n kameran, om den �r det s� �ndras en bool och vi f�rlorar.
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

   // Efter den sista bollen har blivigt skjuten s� startar en timer som r�knar ner och n�r timern �r slut s� f�rlorar man.
    void TimerAfterLastBall()
    {
        if (CannonStats.Instance.ball != null)
        {
            if (CannonStats.Instance.ballAmount == 0)
            {
                timeValue -= Time.deltaTime;
                
                if (timeValue <= 0)
                {
                    CannonStats.Instance.lose = true;
                }
            }
            
        }
        else
        {
            if (CannonStats.Instance.ballAmount == 0)
            {
                timeValue -= Time.deltaTime;
                
                if (timeValue <= 0)
                {
                    CannonStats.Instance.lose = true;
                }
            }
        }
    }
}
