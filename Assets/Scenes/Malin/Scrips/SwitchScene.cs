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
        CannonStats.Instance.cannonActive = false;
    }
    public void NextScene()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex + " " + CannonStats.Instance.nrOfLevels); //Debug, ta bort innan inlämning

        if(SceneManager.GetActiveScene().buildIndex + 1 < CannonStats.Instance.nrOfLevels)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            CannonStats.Instance.cannonActive = true;
            return;
        }

        SceneManager.LoadScene("Menu");
        CannonStats.Instance.cannonActive = true;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        CannonStats.Instance.cannonActive = true;
    }
    public void LevelMenu()
    {
        SceneManager.LoadScene("Level Menu");
        CannonStats.Instance.cannonActive = true;
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay", LoadSceneMode.Additive);
        CannonStats.Instance.cannonActive = false;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(specificScene);
    }
    public void RemovePauseScene()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
        CannonStats.Instance.cannonActive = true;
    }
    public void ReloadScene()
    {
        if(1 < SceneManager.GetActiveScene().buildIndex && SceneManager.GetActiveScene().buildIndex < CannonStats.Instance.nrOfLevels)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
        
        CannonStats.Instance.cannonActive = true;
    }
    public void TimeOn()
    {
        CannonStats.Instance.cannonActive = true;
    }
    public void TimeOff()
    {
        CannonStats.Instance.cannonActive = false;
    }
    public void ExitApplication()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
