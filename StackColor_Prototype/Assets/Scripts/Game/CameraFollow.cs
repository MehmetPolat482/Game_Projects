using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // CAMERA VALUABLES 
    [Header("Camera Target")]
    [SerializeField] private Transform _target; //Public variable to store a reference to the player game object.
    float posZ;  //Private variable to store the offset distance between the player and camera

    // Start is called before the first frame update
    void Start()
    {

        posZ = transform.position.z - _target.transform.position.z;  //Calculate and store the offset value by getting the distance between the player's position and camera's position.
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _target.position.z + posZ);   // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
    }
}
