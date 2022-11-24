using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
	//Oyunda Kullanılan Değişkenler
	private float speed = 14;
	private PlayerController playerControllerScript ;
   
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
		if(playerControllerScript.gameOver == false){
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
		if(transform.position.x < -10 && gameObject.CompareTag("Obstacle")){
			Destroy(gameObject);
		}
		
        
    }
}
