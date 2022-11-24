using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;


    public void OnPauseMenuActive()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnPauseMenuDeactive()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
        
    }
    public void OnRestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

}
