using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

	Transform player;
	float offsetX;

	StartGameManager startGameManager;

	// Use this for initialization
	void Start()
	{
		startGameManager = GameObject.FindGameObjectWithTag("Start Game Manager").GetComponent<StartGameManager>();


		/*	GameObject player_go = GameObject.FindGameObjectWithTag("Ball");
			if (player_go == null)
				return; */
		player = startGameManager.ball.transform;
		offsetX = transform.position.x - player.position.x;

	}

	// Update is called once per frame
	void Update()
	{
		if (player != null)
		{
			Vector3 pos = transform.position;
			pos.x = player.position.x + offsetX;
			transform.position = pos;
		}
	}
}
