using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro ;

public class GameManager : MonoBehaviour
{
	//Oyundaki Skor Değişkenleri
	private int score ;
	public TextMeshProUGUI scoreText ;


    void Start()
    {
        score = 0;
		scoreText.text = "Score : " + score ;
    }
	
	// Çarpışma Sonrasında Coinlerin Durumu ve Skora Yazılması
	private void onTriggerEnter(Collider Coin){
		if(Coin.tag == "Coin"){
			
			score +=1 ;
			Destroy(Coin.gameObject);
			
			scoreText.text = "Score : " + score ;
		}
	}
}
