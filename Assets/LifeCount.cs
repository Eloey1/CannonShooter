using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCount : MonoBehaviour
{
    private int amountOfBalls, currentAmount;
    [SerializeField] private GameObject prefab;
    List<GameObject> list;


    void Start()
    {
        list = new List<GameObject>();
        list.Add(this.gameObject);

        amountOfBalls = CannonStats.Instance.ballAmount;

        for(int i = 1; i < amountOfBalls; i++)
        {
            list.Add(Instantiate(prefab, new Vector3(transform.position.x + 1.1f * i, transform.position.y, transform.position.z), transform.rotation, transform));
        }

        list.Reverse(); //Underlättar så bollarna tas bort i rätt ordning.
    }
    void Update()
    {
        currentAmount = CannonStats.Instance.ballAmount;

        if(currentAmount < list.Count) //Tar bort bollarna när de använts.
        {
            Destroy(list[0]);
            list.RemoveAt(0);
        }
    }
}
