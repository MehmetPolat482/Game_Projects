using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text scoreUIText;
    public Text highScoreText;
    public static int scoreUI;
    public static int score;
    public static int highscore;

    // TEXTS
    public TextMeshProUGUI xText;
    public TextMeshProUGUI comboImpactText;
    public GameObject comboImpact;

    private void Start()
    {
        score = 0;

        highscore = PlayerPrefs.GetInt("highscore", highscore);



    }

    public void Update()
    {

        if (score > highscore)
        {
            highscore = score;
        }
       

        scoreText.text = score.ToString();
        scoreUIText.text = scoreUI.ToString();

        scoreUI = score;
        highScoreText.text = highscore.ToString();

        PlayerPrefs.SetInt("highscore", highscore);
    }


}
