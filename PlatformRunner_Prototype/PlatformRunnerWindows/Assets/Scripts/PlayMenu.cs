using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
	//PlayGame Method
  public void PlayGame(){
	  
	  SceneManager.LoadScene("GameScene");  //Command used to change between Play Menu Screen and Game Screen.
  }
  
	//QuitGame Method
  public void QuitGame(){
	  
	  Application.Quit();  //Command used to exit the game .
  }
}
