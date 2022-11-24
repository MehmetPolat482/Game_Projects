using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
	
	//Game Over Menüsünde Oyunu Tekrar Başlatma
	public void RestartGame(){
		SceneManager.LoadScene("Level-1");
	}
	//Game Over Menüsünde Ana Menüye Gitme
	public void MainMenu(){
		SceneManager.LoadScene("MainMenuScene");
	}
}
