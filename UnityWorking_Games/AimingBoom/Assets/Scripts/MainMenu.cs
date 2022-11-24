using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
 
	public void StartGame()
    {
        SceneManager.LoadScene("Level-1");
		GameManager.DeleteAll();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
