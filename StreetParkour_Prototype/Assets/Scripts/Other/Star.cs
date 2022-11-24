using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [Header("CHARACTER CONTROLLER")]
    CharacterController player;  // Character Controller Script Access
    Transform temas_Cube;   // Object of contact with objects

    // DISTANCE
    float distance;  // Distance between temas_Cube and Object

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        temas_Cube = GameObject.Find("Player/temas_Cube").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.take_magnet == true)
        {
            distance = Vector3.Distance(transform.position, temas_Cube.transform.position);

            if (distance <= 10)
            {
                transform.position = Vector3.MoveTowards(transform.position, temas_Cube.position, Time.deltaTime * 10.0f);
            }
        }
    }
}
