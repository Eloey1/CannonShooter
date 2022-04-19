using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    public void LoadScene() //Malin
    {
        SceneManager.LoadScene("TestBanor");
    }
    public void NextScene() //Malin
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
