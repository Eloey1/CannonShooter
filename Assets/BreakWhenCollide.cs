using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWhenCollide : MonoBehaviour
{
    private void Update()
    {
        OnTriggerBreak2D(GetComponent<BoxCollider2D>());
    }
    private void OnTriggerBreak2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Break plank");
            Destroy(this);
            //goal = true;
        }
    }
}
