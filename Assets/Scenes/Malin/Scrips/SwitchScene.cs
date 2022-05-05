using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour //Malin
{
    public int specificScene;
    public void AddBackground()
    {
        //SceneManager.LoadScene("TestBanor");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Background", LoadSceneMode.Additive);
    }
    public void AddPauseMenu()
    {
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        Time.timeScale = 0;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(specificScene);
    }
    public void RemovePauseScene()
    {
        SceneManager.UnloadScene("PauseMenu");
        Time.timeScale = 1;
    }
}
