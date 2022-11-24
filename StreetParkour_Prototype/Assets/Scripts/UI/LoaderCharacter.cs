using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCharacter : MonoBehaviour
{
    [Header("PLAYER'S VALUABLES")]
    public GameObject the_Boy;  // Male Player GameObject
    public GameObject the_Girl; // Female Player GameObject
    public GameObject spawn_Boy; //  Male Player's SpawnManager
    public GameObject spawn_Girl; //  Female Player's SpawnManager

    [Header("PLAYER'S CAMERA")]
    public Camera camera_Boy;  // Male Player's Camera
    public Camera camera_Girl; // Female Player's Camera

    // Start is called before the first frame update
    void Start()
    {
        the_Boy.SetActive(false);                          
        the_Girl.SetActive(false);
        spawn_Boy.SetActive(false);
        spawn_Girl.SetActive(false);
        camera_Boy.gameObject.SetActive(false);
        camera_Girl.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectCharacter.selected_Character == 0)
        {
            the_Boy.SetActive(true);
            camera_Boy.gameObject.SetActive(true);
            spawn_Boy.SetActive(true);
        }
        else if (SelectCharacter.selected_Character == 1)
        {
            the_Girl.SetActive(true);
            camera_Girl.gameObject.SetActive(true);
            spawn_Girl.SetActive(true);
        }


    }
}
