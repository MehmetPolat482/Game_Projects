using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	// Oyunda Kullanılan Değişkenler
	public GameObject[] obstaclePrefabs;
	public GameObject coinPrefabs;
	public int obstacleIndex;
	private float startDelay = 1f;
	private float repeatRate = 6f;
	private float spawnObstacleLimitXLeft = 20;
	private float spawnObstacleLimitXRight = 70;
	
	private float startDelayCoin = 1f;
	private float repeatRateCoin= 2f;
	private float spawnCoinLimitXLeft = 10;
	private float spawnCoinLimitXRight = 60;
	
	private PlayerController playerControllerScript ;
  
  
    void Start()
    {
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
		InvokeRepeating("SpawnObstacle" , startDelay ,repeatRate);
		
		InvokeRepeating("SpawnCoin" , startDelayCoin ,repeatRateCoin);
       
    }


    void Update()
    {
        
    }
	// Burada Belirli Aralıklarla Nesnelerin Spawn Olması Sağlanması
	void SpawnObstacle(){
		if(playerControllerScript.gameOver == false){
			
			int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
			
			Vector3 spawnPos = new Vector3(Random.Range(spawnObstacleLimitXLeft, spawnObstacleLimitXRight), 0, 0);
			
			Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
			
			
		}
	}
	// Burada Belirli Aralıklarla Coinlerin Spawn Olması Sağlanması
	void SpawnCoin(){
		if(playerControllerScript.gameOver == false){
			
			
			Vector3 spawnPos = new Vector3(Random.Range(spawnCoinLimitXLeft, spawnCoinLimitXRight), 2, 0);
			
			
			Instantiate(coinPrefabs, spawnPos, coinPrefabs.transform.rotation);
	}

}
}
