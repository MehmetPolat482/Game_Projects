using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCircle : MonoBehaviour
{
    private float rotationSpeed;

    private int randRotation;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(20f, 50f);
        randRotation = Random.Range(0, 2) * 2 - 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0,  randRotation * rotationSpeed * Time.deltaTime);
    }

}
