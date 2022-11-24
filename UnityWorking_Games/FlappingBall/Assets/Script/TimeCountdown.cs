using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro ;

public class TimeCountdown : MonoBehaviour
{
	//Değişkenler
	public float time ;
	public TextMeshProUGUI time_Text ;
	public string levelToLoad;
    // Start is called before the first frame update
    void Start()
    {

		time_Text.text = "" + (int)time ;
    }

    // Update is called once per frame
    void Update()
    {
		time -= Time.deltaTime ;
		
		time_Text.text = "" + (int)time ;
		
		if(time <= 0 ){
			
			SceneManager.LoadScene(levelToLoad);
		}
        
    }
}
