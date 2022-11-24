using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rb;
    [Header("GameObject")]
	[SerializeField] private GameObject wall;
    [Header("Bool Conditions")]
	public bool gameContinue = false;
	public bool inTouch = false;
    bool right;
    bool left ;
    [Header("Speed Settings")]
    [Tooltip("Speed value have to be between 0 and 5")]
    [SerializeField] private float speed = 1.5f;
    [Header("Animation")]
	Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();         // We can manipulate rigidbody with GetComponent.
		playerAnim = GetComponent<Animator>();  // We can manipulate animator with GetComponent
    }

    // Update is called once per frame
    void Update()
    {
		if(gameContinue == false){
			    transform.Translate( 0,0,speed * Time.deltaTime);   // The character moves in the z direction , if the game is continue .
		}
    

        Vector3 right_turn = new Vector3(1f ,transform.position.y,transform.position.z);
        Vector3 left_turn = new Vector3(-1f ,transform.position.y,transform.position.z);
		
		if(inTouch == false){
			
			if(Input.touchCount > 0){

            Touch finger = Input.GetTouch(0);

            if(finger.deltaPosition.x > 60.0f){

                right = true;
                left  = false ;
            }
            if(finger.deltaPosition.x < -60.0f){

                right = false;
                left  = true ;
            }
            if(right == true){
                transform.position = Vector3.Lerp(transform.position , right_turn , 4*Time.deltaTime);  //The character moves in the right direction , if the right equals true .
            }
             if(left == true){
                transform.position = Vector3.Lerp(transform.position , left_turn , 4*Time.deltaTime);  //The character moves in the left direction , if the right equals false .
            }
        }
		}
        
	}
	
    //What happens when the character hits the wall.
	private void OnTriggerEnter(Collider other){
		if(other.CompareTag("Wall")){  
			gameContinue=true;
			inTouch = true;
			playerAnim.SetBool("Win_b" , true);
			wall.gameObject.SetActive(true);
		}
        if(other.CompareTag("Plane")){
            SceneManager.LoadScene("GameScene");
        }
    }
	
}

