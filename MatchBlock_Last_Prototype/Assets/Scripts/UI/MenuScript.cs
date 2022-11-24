using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    //BOOL SYSTEM
    bool gamePaused;  


    //Game Pause Method
    public void PauseButton()
    {
        if (gamePaused)
        {
            Time.timeScale = 0f;
            gamePaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            gamePaused = false;
        }
    }

    //Game Restart Method
    public void FirstMap()
    {
        SceneManager.LoadScene(1);
    }
    public void SecondMap()
    {
        SceneManager.LoadScene(2);
    }
    public void ThirdMap()
    {
        SceneManager.LoadScene(3);
    }
    public void FourthMap()
    {
        SceneManager.LoadScene(4);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
