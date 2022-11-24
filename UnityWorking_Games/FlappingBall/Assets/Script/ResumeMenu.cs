using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeMenu : MonoBehaviour
{
	
	//Değişkenler
   public static bool isPaused = false;

	//Oyunun Devam Etmesi
    public void gameResume()
    {
            Time.timeScale = 1f;
            isPaused = false ;
             GetComponent<Rigidbody>().isKinematic = false;
       
    }
}
