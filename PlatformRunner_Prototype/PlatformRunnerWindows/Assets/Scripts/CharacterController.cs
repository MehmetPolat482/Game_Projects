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
    public bool controlContinue = false;
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
    

        float HorizontalInput = Input.GetAxis("Horizontal");
        if(controlContinue == false){
               transform.Translate (HorizontalInput * speed * Time.deltaTime, 0, 0);
        }
     
        
	}
	
    //What happens when the character hits the wall.
	private void OnTriggerEnter(Collider other){
		if(other.CompareTag("Wall")){  
			gameContinue=true;
            controlContinue = true;
			playerAnim.SetBool("Win_b" , true);
			wall.gameObject.SetActive(true);
		}
        if(other.CompareTag("Plane")){
            SceneManager.LoadScene("GameScene");
        }
    }
	
}

