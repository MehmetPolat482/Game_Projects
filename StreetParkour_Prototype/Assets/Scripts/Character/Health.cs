using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //HEALTH SYSTEM
    [Header("PLAYER'S HEALTH")]
    [HideInInspector] public static int health = 3;

    //HEART IMAGES SYSTEM
    [Header("IMAGE OF HEARTS")]
    public Image[] hearts;  // All of the heart's images

    [Header("SPRITES")]
    public Sprite fullHeart;  // FullHearth Sprite 
    public Sprite emptyHeart;  // EmptyHearth Sprite 


    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;  
        }

        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart; // Health system decreasing over time
            
        }
    }
}
