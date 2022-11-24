using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
  
    public GameObject gameOverPanel;
    public GameObject uIPanel;

    StartGameManager startGameManager;

    private void Start()
    {
        startGameManager = GameObject.FindGameObjectWithTag("Start Game Manager").GetComponent<StartGameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            startGameManager.ball.GetComponent<BallController>().gameOver = true;
            StartCoroutine(PanelActive(collision.gameObject));    
            
        }
    }

    IEnumerator PanelActive(GameObject collision)
    {
      
        yield return new WaitForSeconds(3f);

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        uIPanel.SetActive(false);

    }
}
