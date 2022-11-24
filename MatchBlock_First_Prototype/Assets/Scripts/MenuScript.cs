using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    bool gamePaused;
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
    public void RestartButton()
    {
        SceneManager.LoadScene("GameScreen");
    }
}
