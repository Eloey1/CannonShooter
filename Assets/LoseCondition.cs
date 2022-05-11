using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    [SerializeField] private int amountOfBalls;

    void Start()
    {
        CannonStats.Instance.ballAmount = amountOfBalls;
    }

    
    void Update()
    {
        if (CannonStats.Instance.ballAmount == 0)
        {
            CannonStats.Instance.lose = true;
        }
    }
}
