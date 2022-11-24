using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float jumpSpeed;

    public int clickSpeed;

    Rigidbody rigidbodyBall;

    Animator animatorBall;

    Vector3 splashCoordinate;

    public bool isClicked;
    public static bool isGameOver = false;

    UISystem uýSystem;
    ScoreManager scoreManager;

    public GameObject splashPrefabs;
    public GameObject particlePrefabs;

    public GameObject ballFireEffect;
    public GameObject ballSmokeEffect;

    public GameObject boomBall;

    public AudioClip jumpSound;
   // public AudioClip mouseDownSound;
    public AudioSource audioSource;

    public void Awake()
    {
        rigidbodyBall = GetComponent<Rigidbody>();
        uýSystem = GameObject.Find("UISystem").GetComponent<UISystem>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        animatorBall = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
        }

        if (isClicked)
        {
            rigidbodyBall.velocity = Vector3.up * -clickSpeed;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (isClicked)
        {
            if (collision.gameObject.tag == "Good")
            {
                //audioSource.PlayOneShot(mouseDownSound, 0.2f);

                uýSystem.RadialProgress(100f);

                //Destroy(collision.transform.parent.gameObject);
                collision.transform.parent.gameObject.GetComponent<ObstacleController>().ShatterAllObstacle();

                ScoreManager.Instance.ScoreInt += 1;
                uýSystem.SliderSystem(0.5f);
            }
            else if (collision.gameObject.tag == "Bad")
            {
                isGameOver = true;
                GameObject newEffect = GameObject.Instantiate(boomBall , gameObject.transform.position ,  Quaternion.identity);

                Destroy(newEffect, 4f);
                Destroy(gameObject);

                uýSystem.gameOverPanel.SetActive(true);
                uýSystem.uýPanel.SetActive(false);
            }

            if(collision.gameObject.tag == "Finish")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {
            
            rigidbodyBall.velocity = Vector3.up * jumpSpeed;
            audioSource.PlayOneShot(jumpSound, 0.2f);

            ballFireEffect.SetActive(false);
            ballSmokeEffect.SetActive(false);

            animatorBall.SetBool("isTouch", true);
            Invoke("RespawnAnimation", 0.5f);

            splashCoordinate = collision.contacts[0].point;
            GameObject newSplash = GameObject.Instantiate(splashPrefabs,  splashCoordinate + new Vector3(0 , 0.05f ,0), Quaternion.identity);
            GameObject newParticleSplash = GameObject.Instantiate(particlePrefabs, splashCoordinate + new Vector3(0, 0.05f, 0), Quaternion.identity);


            newSplash.transform.parent = collision.gameObject.transform;

            Destroy(newParticleSplash, 0.3f);
            Destroy(newSplash, 3f);
        }
      
    }


    public void RespawnAnimation()
    {
        animatorBall.SetBool("isTouch", false);
    }
}
