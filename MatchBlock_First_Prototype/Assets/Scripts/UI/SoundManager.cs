using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [Header("SOUND ICON LIST")]
    [SerializeField] Image soundOnIcon;   // Volume on icon
    [SerializeField] Image soundOffIcon;    // Volume off icon

    [Header("BOOL SYSTEM")]
    private bool muted = false;         //Is the sound on or off?

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateLoadButton();
        AudioListener.pause = muted;

    }

    public void OnButtonPressed()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;


        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }


        Save();
        UpdateLoadButton();
    }


    private void UpdateLoadButton()
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }


    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
