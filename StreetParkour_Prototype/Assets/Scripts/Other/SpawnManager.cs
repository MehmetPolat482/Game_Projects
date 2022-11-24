using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("OBJECTS FOR SPAWN")]
    public GameObject gold;         // Gold Prefab
    public GameObject magnet;       // Magnet Prefab
    public GameObject powerUp;      // Magnet Prefab
    public GameObject heart;      // Heart Prefab
    public GameObject obstacle_1;   // Obstacle-1 Prefab
    public GameObject obstacle_2;   // Obstacle-2 Prefab
    public GameObject obstacle_3;   // Obstacle-3 Prefab

    [Header("PLAYER'S TRANSFORM")]
    public Transform player;       // Player's Transform in the game

    // 
    [HideInInspector] public float cancelTime = 10.0f;  // Spawn objects extinction time
    [HideInInspector] public float right_X = 1.3f;     // Spawn location on the right
    [HideInInspector] public float middle_ = 0f;     // Spawn location on the right
    [HideInInspector] public float left_X = -2f;       // Spawn location on the left


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Object_Spawn", 0, 0.9f);
    }


    //Spawn Object Function
    void Object_Spawn()
    {
        if (CharacterController.isGameOver == false)
        {
            int randValue = Random.Range(0, 50);

            if (randValue > 0 && randValue <= 32)
            {
                spawn(gold, 1.0f);
            }

            if (randValue > 32 && randValue <= 34)
            {
                if (player.gameObject.GetComponent<CharacterController>().take_powerUp == false)
                {
                    spawn(powerUp, 1.0f);
                }
            }

            if (randValue > 34 && randValue <= 36)
            {
                if (player.gameObject.GetComponent<CharacterController>().take_magnet == false)
                {
                    spawn(magnet, 1.0f);
                }
            }
            if (randValue > 36 && randValue <= 37)
            {

                spawn(heart, 1.0f);

            }
            if (randValue > 37 && randValue <= 42)
            {

                spawn(obstacle_1, 0.0f);

            }
            if (randValue > 42 && randValue <= 46)
            {

                spawn(obstacle_2, 0.0f);

            }
            if (randValue > 46 && randValue <= 50)
            {

                spawn(obstacle_3, 0.0f);

            }
        }
    }

    //Spawn Object Location Function
    void spawn(GameObject objct, float Y_crd)
    {


        if (CharacterController.isGameOver == false)
        {
            GameObject nwe_spawn = Instantiate(objct);

            int randValue = Random.Range(0, 100);

            if (randValue > 0 && randValue <= 30)
            {
                nwe_spawn.transform.position = new Vector3(right_X, Y_crd, player.position.z + 30.0f);
            }
            if (randValue > 30 && randValue <= 60)
            {
                nwe_spawn.transform.position = new Vector3(middle_, Y_crd, player.position.z + 30.0f);
            }
            if (randValue > 60 && randValue <= 100)
            {
                nwe_spawn.transform.position = new Vector3(left_X, Y_crd, player.position.z + 30.0f);
            }
            Destroy(nwe_spawn, cancelTime);
        }


    }
}
