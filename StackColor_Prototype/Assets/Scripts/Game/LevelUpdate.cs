using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpdate : MonoBehaviour
{
    public Image levelLoad;
    public static float currentIndex = 0f;

    void Update()
    {
        levelLoad.fillAmount = currentIndex / 100;
      

    }
}
