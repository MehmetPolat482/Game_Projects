using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
	[Header("Directions")]
    [SerializeField] private float rotatingDirectionZ;
	[SerializeField] private float rotatingDirectionY;
	 [Header("Force Obstacle")]
	[SerializeField] private float force =5.0f ;
    // Update is called once per frame
    void Update()
    {
          transform.Rotate(0,rotatingDirectionY,rotatingDirectionZ);  // Rotation speed and  direction of the obstacle.
    }
	
	 //What happens when the obstacle collision the enemy.
	private void  OnCollisionEnter(Collision collision){
		if(collision.gameObject.CompareTag("Enemy")){
			
			Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
			Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
			enemyRigidbody.AddForce(awayFromPlayer * force , ForceMode.Impulse);
			
		}
}
}
