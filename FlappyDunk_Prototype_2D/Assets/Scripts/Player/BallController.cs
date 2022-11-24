using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	public float jumpForce;
	public Rigidbody2D rb;
	public int combo = 2;

	[SerializeField]
	private float forwardSpeed;

	[SerializeField]
	private float speedLimit;

	bool didFlap = false;

	public bool gameOver = false;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0))
		{
			didFlap = true;
		}
	
	}

    private void FixedUpdate()
    {
		if (!gameOver)
		{
            if (rb.velocity.x < speedLimit)
            {
				rb.AddForce(Vector2.right * forwardSpeed);
			}
			
			Jump();
		}
	}

    public void Jump()
	{
		if (didFlap) {
			rb.velocity = new Vector2 (rb.velocity.x, Vector2.up.y * jumpForce);
			didFlap = false;
		}
	}
}
