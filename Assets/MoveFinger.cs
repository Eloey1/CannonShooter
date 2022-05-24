using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFinger : MonoBehaviour
{
    // Start is called before the first frame update
    float timeLeft = 1.5f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft > 1.2f)
        {
            transform.position += new Vector3(0.02f, -0.03f, 0);
        }

        if (timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }
}
