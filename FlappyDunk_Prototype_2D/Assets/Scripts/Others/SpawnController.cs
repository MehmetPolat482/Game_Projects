using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
	public BallController ball;
	public GameObject obstaclePrefab;

	GameObject obstacle;


	GameObject firstTorus;
	public float minObstacleY;
	public float maxObstacleY;

	public float minObstacleRotation;
	public float maxObstacleRotation;

    private void Start()
    {
		 GameObject firstTorus = GenerateObstacle(ball.transform.position.x + 1);
    }
    public GameObject GenerateObstacle(float x)
	{
		GameObject obstacle = GameObject.Instantiate(obstaclePrefab);
		
		SetTransform(obstacle, x);
		return obstacle;
	}

	void SetTransform(GameObject obstacle, float x)
	{
		obstacle.transform.position = new Vector3(x + 6f, Random.Range(minObstacleY, maxObstacleY), obstacle.transform.position.z);
		obstacle.transform.localRotation = Quaternion.Euler(obstacle.transform.localRotation.eulerAngles.x, Random.Range(minObstacleRotation, maxObstacleRotation), obstacle.transform.localRotation.eulerAngles.z);
	}
	// Update is called once per frame
	void Update()
	{
		if (TorusScript.isTrigged == true && StartGameManager.isStarted == true)
		{
			GenerateObstacle(ball.transform.position.x + 4f);
			Destroy(obstacle, 3f);
			TorusScript.isTrigged = false;
		}
	}

}
