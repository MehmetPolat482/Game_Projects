using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject touchUI;

    public GameObject ball;

    public static bool isStarted = false;



    // Start is called before the first frame update
    void Start()
    {
        touchUI.SetActive(true);
        gameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            touchUI.SetActive(false);
            gameUI.SetActive(true);
            ball.SetActive(true);
        }
    }
}

