using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectCharacter : MonoBehaviour
{
    // LISTS OF CHARACTER
    [Header("CHARACTERS")]
    public GameObject[] Characters;         // List of characters in the game

    // LISTS OF TEXTS
    [Header("TEXTS")]
    public TextMeshProUGUI[] Texts;          // List of character's name in the game

    public static int selected_Character = 0;      //Selected Character Index in SelectMenu
    public int selected_Text = 0;               //Selected Character's NameText Index in SelectMenu



    //Change character with right arrow button
    public void NextMap()
    {
        Characters[selected_Character].SetActive(false);
        Texts[selected_Text].gameObject.SetActive(false);
        selected_Character = (selected_Character + 1) % Characters.Length;
        selected_Text = (selected_Text + 1) % Texts.Length;
        Texts[selected_Text].gameObject.SetActive(true);
        Characters[selected_Character].SetActive(true);
    }

    //Change character with left arrow button
    public void PreviousMap()
    {
        Characters[selected_Character].SetActive(false);
        Texts[selected_Text].gameObject.SetActive(false);
        selected_Text--;
        selected_Character--;
        if (selected_Character < 0)
        {
            selected_Character += Characters.Length;
        }
        if (selected_Text < 0)
        {
            selected_Text += Texts.Length;
        }
        Characters[selected_Character].SetActive(true);
        Texts[selected_Text].gameObject.SetActive(true);
    }

    //Starting the game with the selected character
    public void RunGame()
    {
        PlayerPrefs.SetInt("selected_Character", selected_Character);
    }
}
