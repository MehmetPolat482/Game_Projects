using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    //SCORE SYSTEM

    [Header("SCORE TEXT")]
    public TextMeshProUGUI scoreText_Menu;  // Score Text in the game

    [Header("STAR TEXT")]
    public TextMeshProUGUI starText_Menu; //  Star Text in the game

    [Header("BEST SCORE TEXT")]
    public TextMeshProUGUI bestscoreText_Menu;  //  Best Score Text in the game


    //SCORE MENU SYSTEM

    public static int score_Menu;  // Number of score in the game
    public static int star_Menu;   // Number of star in the game
    public static int bestscore_Menu;   // Number of bestscore in the game

    // Start is called before the first frame update
    void Start()
    {
        bestscore_Menu = PlayerPrefs.GetInt("bestscore");

        BestScore.bestscore =  bestscore_Menu;
    }

    // Update is called once per frame
    void Update()
    {
        score_Menu = CharacterController.point;
        star_Menu = CharacterController.star_point;

        scoreText_Menu.text = score_Menu.ToString();
        bestscoreText_Menu.text = bestscore_Menu.ToString();
        starText_Menu.text = star_Menu.ToString();

        if (score_Menu > bestscore_Menu)
        {
            PlayerPrefs.SetInt("bestscore", score_Menu);
        }


    }
}
