using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BestScoreMenu : MonoBehaviour
{
    [Header("Best Score")]
    public static int bestScore;      // BestScore In The Menu

    [Header("Best Score Text")]
    public Text bestScoreText;   //Bestscoreboard in the menu
    // Update is called once per frame
    void Update()
    {
        bestScoreText.text = bestScore.ToString();
    }
}
