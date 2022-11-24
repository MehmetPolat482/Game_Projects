using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    private int score;

    public static Score Instance;
    public Text scoreText;
    public Text highScoreText;
    // Start is called before the first frame update

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
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

    }

    // Update is called once per frame
    void Update()
    {


    }
}
