using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro ;

public class scoreHandler : MonoBehaviour
{
	//Oyundaki Değişkenler
	public GameObject currentScore;
	
	private TextMeshProUGUI currentScoreText;
	
    // Skor Değerlerinin Oyunun Sonlarına Eklenmesi PlayerPref Yardımıyla
    void Start()
    {
		currentScoreText = currentScore.GetComponent<TextMeshProUGUI>();
		
		currentScoreText.text = PlayerPrefs.GetString("currentScore") + " POINTS";
        
    }
}
