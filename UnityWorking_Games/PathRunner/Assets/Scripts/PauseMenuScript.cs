using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro ;

public class PauseMenuScript : MonoBehaviour
{
	//Oyunda Kullanılan Değişkenler
    public static bool isPaused = false;
    public  GameObject pauseMenu ;



	void Start()
	{
		pauseMenu.SetActive(false);
		
	}
	
	// PauseGame() Fonksiyonuna Bir Durum Eklenmesi
    public void PauseGame()
    {	
		pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true ;
    }
	
	// ResumeGame() Fonksiyonuna Bir Durum Eklenmesi
	public void  ResumeGame(){
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false ;
	}
	
	// RestartGame() Fonksiyonuna Bir Durum Eklenmesi
	public void RestartGame(){
		SceneManager.LoadScene("Level-1");
		Time.timeScale = 1f;
		PlayerController.DeletePlayerPrefs();
		
	}
	
	// MainMenu() Fonksiyonuna Bir Durum Eklenmesi
	public void MainMenu(){
		SceneManager.LoadScene("MainMenu");
	}
}
