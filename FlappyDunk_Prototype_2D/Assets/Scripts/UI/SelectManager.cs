using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    [Header("MAPS")]
    public GameObject[] Maps;        // List of Maps in the game
    public GameObject[] Balls;        // List of Maps in the game
    public static int selected_Map;          //Selected Map Index in SelectMenu    
    public static int selected_Ball;


    //Change map with right arrow button
    public void SelectMap()
    {
        Maps[selected_Map].SetActive(false);
        selected_Map = (selected_Map + 1) % Maps.Length;
        Maps[selected_Map].SetActive(true);
    }

    public void SelectBall()
    {
        Balls[selected_Ball].SetActive(false);
        selected_Ball = (selected_Ball + 1) % Balls.Length;
        Balls[selected_Ball].SetActive(true);
    }


    //Starting the game with the selected map
    public void StartGame()
    {
        PlayerPrefs.SetInt("selected_Map", selected_Map);

        if (selected_Map == 0)
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
        }
        else if (selected_Map == 1)
        {
            SceneManager.LoadScene(2);
            Time.timeScale = 1f;
        }
        else if (selected_Map == 2)
        {
            SceneManager.LoadScene(3);
            Time.timeScale = 1f;
        }
        else if (selected_Map == 3)
        {
            SceneManager.LoadScene(4);
            Time.timeScale = 1f;
        }
        else if (selected_Map == 4)
        {
            SceneManager.LoadScene(5);
            Time.timeScale = 1f;
        }
    }
}
