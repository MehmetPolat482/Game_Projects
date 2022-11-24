using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // LIST OF BALLS
    List<GameObject> ballLists;

    public GameObject ball;

    // LIST OF MAIN BALLS
    public List<GameObject> mainBalls;

    // VALUES
    int level;
    int firstBall = 0;

    // UI
    public Text bigLevelText;
    public Text uILevelText;

    // CAMERA
    public Camera cam;

    public static bool isLosed = false;

    // SUCCESS AND FAIL MENU

    public GameObject successMenu;
    public GameObject failMenu;



    // Start is called before the first frame update
    void Awake()
    {

     
        ballLists = new List<GameObject>();

        isLosed = false;
         LevelControl();
         SpawnManager();

    }

   
    public void LevelControl()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");
            PlayerPrefs.DeleteAll();
        }
        else
        {
            level = 1;
            PlayerPrefs.SetInt("Level", level);
        }

      
        bigLevelText.text = level.ToString();
        uILevelText.text = "LEVEL " + (level+1).ToString();
    }


    public void SpawnManager()
    {
        int allBalls = level + 1;

        int rand = Random.Range(0, mainBalls.Count);
       
        for (int i = allBalls;  i > 0; i --)
        {
            GameObject newBall = Instantiate(ball , new Vector2(0, firstBall) , Quaternion.identity);

            newBall.GetComponent<Circle>().levelText.text = i.ToString();

            ballLists.Add(newBall);

            firstBall--;
        }

        for (int i = 0; i < mainBalls.Count; i++)
        {
                mainBalls[rand].SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && ballLists.Count > 0)
        {
            ballLists[0].GetComponent<Circle>().isMoved = true;

            ballLists.RemoveAt(0);

            foreach (GameObject balls in ballLists)
            {
                balls.transform.position -= new Vector3(0 , -1 , 0);
            }
        }

        if (ballLists.Count == 0)
        {
            cam.backgroundColor = Color.green;
            Invoke(nameof(ContinueLevel), 0.5f);
            
        }

        if (isLosed == true)
        {
            cam.backgroundColor = Color.red;
            CancelInvoke(nameof(ContinueLevel));
            Invoke(nameof(RetryLevel), 0.2f);
        }

    }

    public void ContinueLevel()
    {
        successMenu.SetActive(true);
        Time.timeScale = 0.0f;
      
    }

    public void RetryLevel()
    {
        failMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void SuccessLevelButton()
    {
        SceneManager.LoadScene("PlayMenu");
        level += 1;
        PlayerPrefs.SetInt("Level", level);
        Time.timeScale = 1.0f;
    }

    public void FailLevelButton()
    {
        SceneManager.LoadScene("PlayMenu");
        level = 1;
        Time.timeScale = 1.0f;
    }


}
