using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("PLAYER TRANSFORM")]
    [SerializeField] private Transform player;  // Player's Transform Variable
    [HideInInspector] public Vector3 offset;  // Offset Variable

    // Start is called before the first frame update
    private void Start()
    {
        offset = transform.position - player.position;  // Offset Between Camera and Player 
    }

    // Update is called once per frameF
    private void Update()
    {
        Vector3 targetPos = player.position + offset;  // Distance Of The Camera To Follow The Player

        transform.position = targetPos;   // New Position Of Follower Camera
    }
}
