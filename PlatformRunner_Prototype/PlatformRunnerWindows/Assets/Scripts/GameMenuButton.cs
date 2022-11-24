using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuButton : MonoBehaviour
{
 
	public void RestartGame(){
		SceneManager.LoadScene("GameScene");   // Game scene is loading with this coommand.
	}
	public void MainMenu(){
		SceneManager.LoadScene("PlayMenu");   // Play menu scene is loading with this coommand.
	}
}
