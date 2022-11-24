using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeNumbers : MonoBehaviour
{

    //VALUE CUBE
    public int value;

    //PARTICLE SYSTEM
    public GameObject particleEffect; 

    //NEXT CUBE 
    public GameObject nextCube;

    //OBJECT'S ID 
    public int ID;

    //RIGIDBODY
    public Rigidbody rb;

    //CAMERA CONTROL
    CameraControl cameraControl;

    //CAMERA CONTROL
    Score score;


    void Start()
    {
        cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
        score = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Score>();
        ID = GetInstanceID();
        rb = GetComponent<Rigidbody>();
    }

    public void SendCube()
    {
        rb.AddForce(transform.forward * 80);
    }


    public void CreatingForce()
    {
        rb.AddForce(Vector3.up * 20);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            if (collision.gameObject.TryGetComponent(out CubeNumbers cubeNumbers))
            {
                if (cubeNumbers.value == value)
                {
                    if (ID < cubeNumbers.ID) return;
                    Destroy(collision.gameObject);

                    cameraControl.CameraShaking();

                    if (nextCube != null)
                    {
                        GameObject temp = Instantiate(nextCube, transform.position, transform.rotation);

                        GameObject particleNew = GameObject.Instantiate(particleEffect, transform.position, transform.rotation);

                        Destroy(particleNew, 2.0f);

                   

                        if (temp.TryGetComponent<CubeNumbers>(out CubeNumbers nextForceCube))
                        {
                            nextForceCube.CreatingForce();
                        }
                    }
                  
                    Destroy(this.gameObject);

                    Score.Instance.ScoreInt += cubeNumbers.value;
                   
                }
            }
        }
    }    

}
