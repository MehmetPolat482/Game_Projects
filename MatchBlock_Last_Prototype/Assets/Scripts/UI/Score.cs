using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    //SCORE VARIABLES
    public static int score;
    [HideInInspector] public int addScore;
    public static Score Instance;

    //TEXT VARIABLES
    public Text scoreText;   
    public Text highScoreText;
   
    //CUBENUMBERS
    CubeNumbers cubeNumbers;

    public int ScoreInt
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = score.ToString();

            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
                highScoreText.text = score.ToString();
            }
        }
    }

    void Awake()
    {

        Instance = this;

        if (!PlayerPrefs.HasKey("HighScore"))
            PlayerPrefs.SetInt("HighScore", 0);

        scoreText.text = "0";
        score = 0;
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        BestScoreMenu.bestScore = PlayerPrefs.GetInt("HighScore");


    }

    private void Start()
    {
        cubeNumbers = GameObject.FindGameObjectWithTag("Cube").GetComponent<CubeNumbers>();
    }
}
