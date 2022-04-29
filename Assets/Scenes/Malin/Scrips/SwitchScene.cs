using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] int specificScene;
    public void AddBackground() //Malin
    {
        //SceneManager.LoadScene("TestBanor");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Background", LoadSceneMode.Additive);
    }
    public void AddPauseMenu()
    {
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
    }
    public void NextScene() //Malin
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
