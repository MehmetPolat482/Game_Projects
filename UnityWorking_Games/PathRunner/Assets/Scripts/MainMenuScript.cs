using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //Burada PlayGame() fonksiyonunun ne yapması gerektiği belirtildi.
	public void PlayGame(){
		SceneManager.LoadScene("Level-1");
		Time.timeScale = 1f;
		PlayerController.DeletePlayerPrefs();
	}
	//Burada MainMenu() fonksiyonunun ne yapması gerektiği belirtildi.
	public void MainMenu(){
		SceneManager.LoadScene("MainMenu");
	}
	//Burada QuitGame() fonksiyonunun ne yapması gerektiği belirtildi.
	public void QuitGame(){
		Application.Quit();
	}

}
