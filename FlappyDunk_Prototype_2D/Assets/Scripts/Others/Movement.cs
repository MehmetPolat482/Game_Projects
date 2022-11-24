using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static float speed = 1f;

    void Update()
    {
        
        transform.position += ((Vector3.right * speed) * Time.deltaTime);
      
    }
}
