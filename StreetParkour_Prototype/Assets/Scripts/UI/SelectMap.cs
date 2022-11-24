using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour
{
    [Header("MAPS")]
    public GameObject[] Maps;        // List of Maps in the game
    public static int selected_Map = 0;          //Selected Map Index in SelectMenu


    //Change map with right arrow button
    public void NextMap()
    {
        Maps[selected_Map].SetActive(false);
        selected_Map = (selected_Map + 1) % Maps.Length;
        Maps[selected_Map].SetActive(true);
    }

    //Change map with left arrow button
    public void PreviousMap()
    {
        Maps[selected_Map].SetActive(false);
        selected_Map--;
        if (selected_Map < 0)
        {
            selected_Map += Maps.Length;
        }
        Maps[selected_Map].SetActive(true);
    }

     //Starting the game with the selected map
    public void StartGame()
    {
        PlayerPrefs.SetInt("selected_Map", selected_Map);

        if (selected_Map == 0)
        {
            SceneManager.LoadScene(2);
        }
        else if (selected_Map == 1)
        {
            SceneManager.LoadScene(3);
        }
    }
}

