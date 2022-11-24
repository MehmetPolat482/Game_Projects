using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActivate : MonoBehaviour
{
    [Header("PAUSE MENU")]
    public GameObject pause_Menu; // Pause Menu

    public void DayTime()
    {
        SceneManager.LoadScene("GameScreenDay");  //GameScreenDay scene upload command
    }


    public void NightTime()
    {
        SceneManager.LoadScene("GameScreenNight"); //GameScreenNight scene upload command
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");    // Start Menu scene upload command

        Time.timeScale = 1f;      // Stop Time
    }


    public void PauseGame()
    {
        pause_Menu.SetActive(true);
        Time.timeScale = 0f;      // Stop Time
    }

    public void ResumeGame()
    {
        pause_Menu.SetActive(false);
        Time.timeScale = 1f;   // Continue Time
    }

    public void RestartGame()
    {
        pause_Menu.SetActive(false);
        CharacterController.isGameActive = true;

        if (SelectMap.selected_Map == 0)
        {
            SceneManager.LoadScene(2);
            CharacterController.isGameActive = true;
        }
        else if (SelectMap.selected_Map == 1)
        {
            SceneManager.LoadScene(3);
            CharacterController.isGameActive = true;
        }

        Time.timeScale = 1f;   // Continue Time
    }
}
