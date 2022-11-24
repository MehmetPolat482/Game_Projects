using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionObstacle : MonoBehaviour
{
    [Header("Max-Min Value")]
    [SerializeField] private float min;
    [SerializeField] private float max;
    [Header("Direction")]
	[SerializeField] private float direction ;
    [Header("Force Obstacle")]
	[SerializeField] private float force =5.0f ;
    // Use this for initialization
    void Start () {
       
        min=transform.position.x;
        max=transform.position.x+2;
   
    }
   
    // Update is called once per frame
    void Update () {
       
       
        transform.position =new Vector3(direction * Mathf.PingPong(Time.time*1,max-min)+min, transform.position.y, transform.position.z); // Direction speed ve time of the obstacle.
       
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
