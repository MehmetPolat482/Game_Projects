using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour
{
   
    public void PinkScene()
    {
        SceneManager.LoadScene(1);
    }

    public void RedScene()
    {
        SceneManager.LoadScene(2);
    }

    public void BlueScene()
    {
        SceneManager.LoadScene(3);
    }

    public void PurpleScene()
    {
        SceneManager.LoadScene(4);
    }

}
