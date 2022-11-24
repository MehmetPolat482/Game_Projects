using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusScript : MonoBehaviour {

	GameObject ballGameObject;
	BallController ballController;
	bool touchedBad = false;
	bool gotPoint = false;

	public Animator animatorObstacle;
	public GameObject starEffect;

    public static bool isTrigged = false;


	StartGameManager startGameManager;

	ScoreManager scoreManager;

	// ShakeController shakeController;

	// Use this for initialization
	void Start () {

		// shakeController = GameObject.FindGameObjectWithTag("ShakeController").GetComponent<ShakeController>();
		scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
		startGameManager = GameObject.FindGameObjectWithTag("Start Game Manager").GetComponent<StartGameManager>();
	}
	

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ball") {
			startGameManager.ball.GetComponent<BallController>().combo = 1;
			touchedBad = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Ball") {
			isTrigged = true;
			if (!gotPoint) {
				gotPoint = true;
				if (!touchedBad)
                {
					startGameManager.ball.GetComponent<BallController>().combo++;

					ComboText();
				}
					
				//shakeController._isShake = true;
				//shakeController.ShakeSystem();
			}
			
			ScoreManager.score += ballController.combo;
			
			if (startGameManager.ball.GetComponent<BallController>().combo > 2)
			{
				scoreManager.comboImpactText.text = "SWISH!";
				Instantiate(starEffect, other.transform.position, other.transform.rotation);

				Destroy(starEffect, 3f);
			}
			else if (startGameManager.ball.GetComponent<BallController>().combo > 3)
			{
				scoreManager.comboImpactText.text = "PERFECT!";
				Instantiate(starEffect, other.transform.position, other.transform.rotation);

				Destroy(starEffect, 3f);
			}
			else if (startGameManager.ball.GetComponent<BallController>().combo > 4)
			{
				scoreManager.comboImpactText.text = "FANTASTIC!";
				Instantiate(starEffect, other.transform.position, other.transform.rotation);

				Destroy(starEffect, 3f);
			}



			StartCoroutine(AnimationObstacle());
			
			
		}
	}

	
	IEnumerator AnimationObstacle()
    {
		animatorObstacle.SetBool("Interact", true);
		yield return new WaitForSeconds(2f);
		animatorObstacle.SetBool("Interact", false);
	}

	public void ComboText()
    {
		
		scoreManager.xText.text = "X" + startGameManager.ball.GetComponent<BallController>().combo.ToString();

			StartCoroutine(TextActive());


	}

	IEnumerator TextActive()
    {
		scoreManager.comboImpact.gameObject.SetActive(true);
		yield return new WaitForSeconds(1f);
		scoreManager.comboImpact.gameObject.SetActive(false);
	}
	
}
