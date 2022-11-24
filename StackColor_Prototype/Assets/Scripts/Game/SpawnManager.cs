using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("OBJECTS FOR SPAWN")]
    public GameObject _pickupGround;         // Pickup_Ground Prefab
    public GameObject _colorWall;         // Pickup_Ground Prefab

    [Header("PLAYER'S TRANSFORM")]
    public Transform player;       // Player's Transform in the game



    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("Object_Spawn", 0, 4f);

    }


    //Spawn Object Function
    void Object_Spawn()
    {
        int index = Random.Range(1, 10);

        if (index >= 1 && index <= 3)
        {
            spawn(_colorWall);

        }

        else if (index >= 3 && index <= 10)
        {
            spawn(_pickupGround);

        }

    }

    //Spawn Object Location Function
    void spawn(GameObject objct)
    {

        GameObject new_spawn = Instantiate(objct);
        
        if (objct == _colorWall)
        {
            new_spawn.transform.position = new Vector3(0f, 1f, player.position.z + 20.0f);
        }
        else if (objct == _pickupGround)
        {
            new_spawn.transform.position = new Vector3(0f, 0.06f, player.position.z + 20.0f);
        }

    }
}
