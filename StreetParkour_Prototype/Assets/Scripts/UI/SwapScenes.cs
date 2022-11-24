using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameScreenDay")
        {
            BackgroundMusic.instance.GetComponent<AudioSource>().Pause();
        }
    }
}
