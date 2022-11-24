using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
       private void OnTriggerEnter(Collider other){
        if (other.CompareTag("ColorWall")){
        print("TEST");
        }
       }
}
