using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class OpponentController : MonoBehaviour
{
    private Rigidbody rb;
	[Header("Transforms")]
	[SerializeField] private Transform goal ;
	[SerializeField] private Transform player;

	[Header("Bool Condition")]
	[SerializeField] private bool gameContinue = false;
	Animator playerAnim;
     public float speed;
    // Start is called before the first frame update
    void Start()
    {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();   // We can manipulate NavMeshAgent with GetComponent.
		playerAnim = GetComponent<Animator>();    			// We can manipulate Animator with GetComponent.
		agent.destination = goal.position; 					// The opponent moves towards the target.
        rb = GetComponent<Rigidbody>(); 					// We can manipulate Rigidbody with GetComponent.
    }

    // Update is called once per frame
    void Update()
    {
		if(gameContinue == false){
        transform.Translate(0, 0, speed * Time.deltaTime);  // The character moves in the z direction , if the game is continue .
		}
		
    }
	
	
	
	//What happens when the character hits the walls.
	private void OnTriggerEnter(Collider other){
		
		if(other.CompareTag("Wall")){
			playerAnim.SetBool("Win_b" , true);
			gameContinue=true;
		}
		if(other.CompareTag("DieWall")){
			
			
			StartCoroutine(GameOverCountdownRoutine()) ;
		}
		
	}
	//When happens when the character hits the walls.
	IEnumerator GameOverCountdownRoutine() {
		yield return new  WaitForSecondsRealtime(2f);
		Destroy(gameObject);

	}

}
