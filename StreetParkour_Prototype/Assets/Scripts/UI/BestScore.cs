using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BestScore : MonoBehaviour
{
    [Header("Best Score Text")]
    public TextMeshProUGUI bestscoreText;

    [HideInInspector] public static int bestscore;

    void Update()
    {
        bestscoreText.text = bestscore.ToString("00000");
    }
}
