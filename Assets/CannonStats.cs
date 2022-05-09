using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonStats : MonoBehaviour
{
    public static CannonStats Instance { get; set; }

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
}
