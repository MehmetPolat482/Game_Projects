using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   //Ana Menü Başlatma Komutu
 	public void RestartGame(){
		SceneManager.LoadScene("Level-1");
	}
	//Ana Menü Oyundan Çıkma Komutu
	public void QuitGame(){
		Application.Quit();
	}

}
