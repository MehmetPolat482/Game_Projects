using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BestScoreMenu : MonoBehaviour
{
    // BESTSCORE VALUE
    public static int bestScore;

    //BESTSCORE GAMEOBJECT
    public GameObject bestScoreMenu;

    // BOOL SYSTEM
    bool isClicked;

    //BESTSCORE TEXT
    public Text bestScoreText; 
    // Update is called once per frame
    void Update()
    {
        bestScoreText.text = bestScore.ToString();
    }

    public void BestScore()
    {
        isClicked = !isClicked;

        if (isClicked)
        {
            bestScoreMenu.SetActive(true);
        }
        else
        {
            bestScoreMenu.SetActive(false);
        }
    }
}
