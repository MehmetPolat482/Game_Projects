using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro ;

public class PlayerController : MonoBehaviour
{
	//Oyunda Kullanılan Player Değişkenleri
	private Rigidbody playerRb;
	private Animator playerAnim;
	private AudioSource playerSource;
	public float jumpForce;
	public float gravityModifier;
	public AudioClip jumpAudio;
	public AudioClip crashAudio;
	public AudioClip collectAudio;
	public bool isOnGround = true ;
	public bool gameOver = false;
	public ParticleSystem explosionParticle; 
	public ParticleSystem dirtParticle;
	private GameManager gameManager ;
	public GameObject coinPrefab;
	public bool hasCoin = false ;
	private int score ;
	public TextMeshProUGUI scoreText ;
   
   
    void Start()
    {
	
	if(PlayerPrefs.HasKey("score")){
		
		score = PlayerPrefs.GetInt("score");
		scoreText.text = "Score : " + score ;
		
	}
		scoreText.text = "Score : " + score ;
		
        playerRb = GetComponent<Rigidbody>();
		playerAnim = GetComponent<Animator>();
		playerSource = GetComponent<AudioSource>();
		Physics.gravity *= gravityModifier ;
		
		
    }

  
  
    void Update()
    {
	
    }
	
	public void JumpButton(){
		
		if(isOnGround == true ){
			
			playerRb.AddForce(Vector3.up*jumpForce , ForceMode.Impulse) ;
			isOnGround = false ;
			playerAnim.SetTrigger("Jump_trig");
			dirtParticle.Stop();
			playerSource.PlayOneShot(jumpAudio , 1.0f);
		}
			
		
	}
	
	//PlayerPref Yardımıyla Veri Saklanması 
	public static void DeletePlayerPrefs(){
		PlayerPrefs.DeleteAll();
	}
	//Player'ın Çarpışma Sonrasındaki Etkileri Ne Olduğu Söylenmesi
	private void OnCollisionEnter(Collision collision){
		
		if(collision.gameObject.CompareTag("Ground")){
			isOnGround= true;
			dirtParticle.Play();
		}
		else if(collision.gameObject.CompareTag("Obstacle")) {
			
			
			gameOver = true ;
			playerAnim.SetBool("Death_b",true);
			playerAnim.SetInteger("DeathType_int",1);
			explosionParticle.Play();
			playerSource.PlayOneShot(crashAudio , 1.0f);
			dirtParticle.Stop();
			PlayerPrefs.SetString("currentScore" , scoreText.text);
			StartCoroutine(GameOverCountdownRoutine()) ;
			
		}
	}
	// Burada Belirli Zaman İçinde İşlem Yapılması Sağlanması
	IEnumerator GameOverCountdownRoutine() {
		yield return new  WaitForSecondsRealtime(2f);
		SceneManager.LoadScene("GameOverScene");

	}
	
	// Burada Çarpışma Sonrası Skor Sayımı Yapılması Sağlanması
	private void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Coin") ){
			Destroy(other.gameObject);
			hasCoin = true ;
			playerSource.PlayOneShot(collectAudio , 1.0f);
			
			score +=1 ;
			PlayerPrefs.SetInt("score" , score);
			scoreText.text = "Score : " + score;
				
			LevelScene();
	}		
			
		}
		
		// Burada Her Levelin Ne Kadar Sürede Sürmesi Belirtilmesi
		
	private void LevelScene(){
		if(score == 15){
			SceneManager.LoadScene("Level-2");
		}else if(score == 30){
			SceneManager.LoadScene("Level-3");
		}else if(score == 45){
			SceneManager.LoadScene("Level-4");
		}else if(score == 60){
			SceneManager.LoadScene("Level-5");
		}else if(score == 75){
			SceneManager.LoadScene("Final Level");
		}else if(score == 100){
			SceneManager.LoadScene("WinScene");
		}
		
	}		
}
	
