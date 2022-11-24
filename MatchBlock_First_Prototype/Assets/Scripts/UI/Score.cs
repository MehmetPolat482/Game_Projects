using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    [Header("Score")]
    public static int score;  // Score In The Game
    public static Score Instance;

    [Header("Texts")]
    public Text scoreText;   //scoreboard in the game
    public Text highScoreText;  //Bestscoreboard in the game


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
        PlayerPrefs.DeleteAll();

    }
}
