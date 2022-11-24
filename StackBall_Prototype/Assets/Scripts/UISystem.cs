using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UISystem : MonoBehaviour
{

    public Image levelSlider;
    public  float currentLevel;
    private float totalObstacleCount = 250;

    public Image radialProgressBar;
    public float currentBar;

    // PANEL GAMEOBJECTS

    public GameObject uýPanel;
    public GameObject gameOverPanel;

    //ACTIVE SCENE NAME
    public int activeScene;

    //BALL CLASS
    Ball ball;
    

    private void Awake()
    {
        ball = GameObject.Find("Ball").GetComponent<Ball>();
    }

    private void Start()
    {
        currentBar = 0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {

        RadialFunction();
    }

    public void RadialFunction()
    {

        radialProgressBar.fillAmount = currentBar / 100f;
        currentBar -= 15f * Time.deltaTime;

        if (currentBar < 0)
        {
            currentBar = 0;
            radialProgressBar.gameObject.SetActive(false);

        }
        if (currentBar > 100)
        {
            currentBar = 100f;
        }

        if (currentBar > 40f)
        {
           ball.ballFireEffect.SetActive(true);
        }

        if (currentBar > 60f)
        {
            ball.ballSmokeEffect.SetActive(true);
        }
    }

    public void SliderSystem(float addCount)
    {
        levelSlider.fillAmount = currentLevel * 100f / totalObstacleCount;

        currentLevel += addCount * Time.deltaTime;
        
    }


    public void RadialProgress(float barCount)
    {
        radialProgressBar.fillAmount = currentBar / 100f;

        currentBar += barCount * Time.deltaTime;
        radialProgressBar.gameObject.SetActive(true);

    }



    public void PanelControl()
    {
        if (Input.GetMouseButton(0) && Ball.isGameOver == true)
        {
            SceneManager.LoadScene(activeScene);
        }
    }
}
