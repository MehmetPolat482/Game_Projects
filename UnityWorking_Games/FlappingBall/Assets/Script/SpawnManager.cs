using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	//Değişkenler
	 public GameObject[] enemyPrefab ;
	 public int enemyIndex;
	 public GameObject powerupPrefab ;
	 private float spawnRange = 12.0f ;
	 public int enemyCount ;
	 public int waveNumber = 2;
	 
    // Start is called before the first frame update
    void Start()
    {
		SpawnEnemyWave(waveNumber);
		Instantiate(powerupPrefab ,GenerateSpawnPosition() ,powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<FollowEnemy>().Length;
		
		if(enemyCount == 0){
			waveNumber++;
			SpawnEnemyWave(waveNumber);
			Instantiate(powerupPrefab ,GenerateSpawnPosition() ,powerupPrefab.transform.rotation);
		}
    }
	// Kaç Tane Düşman Çoğaltması Komutu
	void SpawnEnemyWave(int enemiestoSpawn ){
		
		for(int i=0 ; i < enemiestoSpawn ; i++){
			
		int enemyIndex = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[enemyIndex] , GenerateSpawnPosition() ,enemyPrefab[enemyIndex].transform.rotation);
		}
	}
	// Hangi Konumunda Düşman Çoğaltması Yapma Komutu
	private Vector3 GenerateSpawnPosition() { 
		float spawnPosX = Random.Range(-spawnRange , spawnRange);
		float spawnPosZ = Random.Range(-spawnRange , spawnRange);
		Vector3 randomPos = new Vector3(spawnPosX, -1 ,spawnPosZ);
		return randomPos ;
	}
}
