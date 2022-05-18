using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonStats : MonoBehaviour
{
    public static CannonStats Instance { get; set; } = new CannonStats();

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public float shootForce;
    public Vector2 rotation;
    public bool lose = false;
    public int ballAmount;
    public GameObject ball;
    public Rigidbody2D ballRb;
    //public SpriteRenderer ballInView;
}
