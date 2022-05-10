using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour //Malin
{
    public int specificScene;
    public void AddBackground()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneByName("Background").isLoaded)
            {
                return;
            }
        }

        SceneManager.LoadScene("Background", LoadSceneMode.Additive);
    }
    public void AddPauseMenu()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneByName("PauseMenu").isLoaded || SceneManager.GetSceneByName("BetweenLevels").isLoaded)
            {
                return;
            }
        }
        
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
        Time.timeScale = 1;
    }
    public void LevelMenu()
    {
        SceneManager.LoadScene("Level Menu");
        Time.timeScale = 1;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(specificScene);
    }
    public void RemovePauseScene()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void TimeOn()
    {
        Time.timeScale = 1;
    }
    public void TimeOff()
    {
        Time.timeScale = 0;
    }
}
