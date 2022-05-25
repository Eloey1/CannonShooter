using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CannonStats : MonoBehaviour
{
    public float shootForce;
    public Vector2 rotation;
    public bool lose = false, cannonActive, threadActive;
    public int ballAmount;
    public GameObject ball;
    public Rigidbody2D ballRb;
    public bool win = false;
    public int nrOfLevels = 17;

    public static CannonStats Instance { get; set; } = new CannonStats();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (CannonStats.Instance.lose && !SceneManager.GetSceneByName("RestartMenu").isLoaded)
        {
            SceneManager.LoadScene("RestartMenu", LoadSceneMode.Additive); //Tar upp restart-menyn
            //Time.timeScale = 0; //Pausar tiden
            CannonStats.Instance.cannonActive = false;

            if (SceneManager.GetSceneByName("Background").isLoaded)
            {
                //Unload burger button
            }
        }
    }

}
