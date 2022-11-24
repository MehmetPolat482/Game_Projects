using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //SCORE VARIABLES
    public int score;
    [HideInInspector]
    public int uýScore;
    [HideInInspector] public int addScore;
    public static ScoreManager Instance;

    //TEXT VARIABLES
    public Text scoreText;
    public Text uýScoreText;
    public Text uýHighScoreText;


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

           // scoreText.text = uýScoreText.text;

            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
                uýHighScoreText.text = score.ToString();
            }
        }
    }

    void Awake()
    {

        Instance = this;

        if (!PlayerPrefs.HasKey("HighScore"))
            PlayerPrefs.SetInt("HighScore", 0);

        uýHighScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void Start()
    {
        score = 0;
    }
}
