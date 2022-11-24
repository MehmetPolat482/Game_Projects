using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButton : MonoBehaviour
{

    //Going to the SelectMenu Screen
    public void MenuChange()
    {
        SceneManager.LoadScene("SelectMap");
    }

    //Going to the Start the Game Screen
    public void RunGame()
    {
        SceneManager.LoadScene("GameScreenDay");
    }

    //Going to the MainMenu Screen
    public void BackMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
