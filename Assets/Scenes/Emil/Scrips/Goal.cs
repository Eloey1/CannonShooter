using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    //[SerializeField] bool goal = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("GOAL!!!");
            Destroy(collision.gameObject);
            SceneManager.LoadScene("BetweenLevels", LoadSceneMode.Additive);
            Time.timeScale = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
            //goal = true;
        }
    }
}
