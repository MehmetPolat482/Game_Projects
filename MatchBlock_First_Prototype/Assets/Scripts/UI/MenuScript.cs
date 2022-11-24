using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [Header("Bool System")]
    bool gamePaused;   // Did the game stop?


    //Game pause function
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

    //Game restart function
    public void RestartButton()
    {
        SceneManager.LoadScene("GameScreen");
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
