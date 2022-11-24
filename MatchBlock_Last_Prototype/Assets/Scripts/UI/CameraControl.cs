using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraControl : MonoBehaviour
{

   public void CameraShaking()
    {
        gameObject.GetComponent<CameraShaker>().ShakeOnce(5, 3, 0.1f, 2f);
    }
}
