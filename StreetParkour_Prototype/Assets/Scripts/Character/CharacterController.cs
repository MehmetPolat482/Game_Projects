using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterController : MonoBehaviour
{
    // PLAYER ANIMATION

    [Header("PLAYER ANIMATOR")]
    [HideInInspector] public static Animator Anim; // Player Animator

    // PARTICLE SYSTEMS

    [Header("PARTICLE SYSTEMS")]
    public ParticleSystem star_Particle;  // Star Particle
    public ParticleSystem magnet_Particle;  // Magnet Particle
    public ParticleSystem powerUp_Particle;  // PowerUp Particle
    public ParticleSystem heart_Particle;  // PowerUp Particle
    public ParticleSystem crash_Particle;  // Crash Particle

    // IMAGE SYSTEM

    [Header("IMAGES")]
    public Image multiplier_PowerUp;  // Multiplier PowerUp Image
    public Image magnet_Img;    // Magnet Image

    // TEXT SYSTEM

    [Header("TEXTMESHPROUGUI")]
    public TextMeshProUGUI point_txt;  // Score Text
    public TextMeshProUGUI star_point_txt;  // Start Value  

    // TRANSFORM SYSTEM

    [Header("TRANSFORMS")]
    public Transform street1;      // Repeated path transform
    public Transform street2;      // Repeated path transform

    // BOOL SYSTEM

    [Header("BOOL VARIABLES")]
    public bool isOnGround = true;  // Is the player touching the ground or not?
    bool left;      // Does the player go left or not
    bool right;      // Does the player go right or not
    public static bool isGameOver = false;  // Is the game over or not?
    public static bool isGameActive = false;
    public bool take_magnet;  // Magnet taken or not?
    public bool take_powerUp; // PowerUp taken or not?

    // PLAYER MOVEMENT SYSTEM

    [Header("PLAYER MOVEMENT VARIABLES")]
    public float jumpForce;  // Player's jump force
    public float gravityModifier; // Player's gravity
    public int speed;  // Player's running speed

    [HideInInspector] public float jumpIndex;  // Player's jump animations

    [HideInInspector] public Rigidbody rb;  // Player's Rigidbody

    // SCORE SYSTEM
    public static int point;  // Score in the game
    public static int star_point; // Number of stars collected in the game

    // GAME OVER MENU SYSTEM
    [Header("GAME OVER MENU")]
    public GameObject GameOverScreen;  // Game Over Menu

    // AUDIO SOURCE SYSTEM
    [Header("AUDIO SOURCES")]
    public AudioSource soundAudio;  // Sound source in the game
    public AudioSource sound_mag_Audio; // Magnet sound source in the game

    // AUDIO CLIP SYSTEM
    [Header("AUDIO CLIPS")]
    public AudioClip star_sound;  // Collecting stars sound
    public AudioClip magnet_sound;  // Collecting magnet sound
    public AudioClip powerUp_sound; // Collecting powerup sound
    public AudioClip heart_sound; // Collecting powerup sound
    public AudioClip crashAudio;  // Crash sound
    public AudioClip jumpAudio;  // Jump sound

    void Start()
    {
        GameOverScreen.SetActive(false);
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        multiplier_PowerUp.gameObject.SetActive(false);
        magnet_Img.gameObject.SetActive(false);
        Physics.gravity *= gravityModifier;

        if (isGameActive == false)
        {
            PlayerPrefs.GetInt("health", Health.health);
            PlayerPrefs.GetInt("star", star_point);
            star_point_txt.text = star_point.ToString();

            PlayerPrefs.GetInt("point", point);
            point_txt.text = point.ToString("00000");
        }
    }

    void Update()
    {
        Move();
    }


    // JUMP FUNCTION

    // COLLIDER FUNCTION
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Start_1")
        {
            street2.position = new Vector3(street1.position.x, street1.position.y, street1.position.z + 117.0f);
        }
        if (other.gameObject.name == "Start_2")
        {
            street1.position = new Vector3(street2.position.x, street2.position.y, street2.position.z + 117.0f);
        }

        if (other.gameObject.tag == "star")
        {
            soundAudio.PlayOneShot(star_sound, 1.0f);
            Destroy(other.gameObject);
            star_Particle.Play();

            point += 5;
            star_point++;

            point_txt.text = point.ToString("00000");
            star_point_txt.text = star_point.ToString();

        }
        if (other.gameObject.tag == "heart")
        {
            soundAudio.PlayOneShot(heart_sound, 1.0f);
            Destroy(other.gameObject);
            heart_Particle.Play();

            if (Health.health < 3)
            {
                Health.health++;
            }
        }
        if (other.gameObject.tag == "magnet")
        {

            StartCoroutine(Magnet());
            GameObject[] all_magnet = GameObject.FindGameObjectsWithTag("magnet");


            foreach (GameObject magnet in all_magnet)
            {
                Destroy(magnet);
                take_magnet = true;
                magnet_Particle.Play();
                Invoke("Magnet_Reset", 10.0f);
            }
        }

        if (other.gameObject.tag == "MultiplierPowerUp")
        {
            StartCoroutine(MultiplierPowerUp());
            GameObject[] all_powerUp = GameObject.FindGameObjectsWithTag("MultiplierPowerUp");

            foreach (GameObject powerUp in all_powerUp)
            {
                Destroy(powerUp);
                take_powerUp = true;
                soundAudio.PlayOneShot(powerUp_sound, 1.0f);
                powerUp_Particle.Play();
                Invoke("PowerUp_Reset", 10.0f);
            }

        }

    }

    // FUNCTION MADE IN A CERTAIN TIME INTERVAL.
    IEnumerator MultiplierPowerUp()
    {
        multiplier_PowerUp.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        multiplier_PowerUp.gameObject.SetActive(false);
    }

    // FUNCTION MADE IN A CERTAIN TIME INTERVAL.
    IEnumerator Magnet()
    {
        sound_mag_Audio.Play();
        magnet_Img.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        sound_mag_Audio.Stop();
        magnet_Img.gameObject.SetActive(false);
    }

    //RESET MAGNET FUCNTION
    void Magnet_Reset()
    {
        take_magnet = false;
    }

    //RESET POWERUP FUCNTION
    void PowerUp_Reset()
    {
        take_powerUp = false;
    }

    // MOVEMENT FUNCTION
    void Move()
    {

        Vector3 rightPos = new Vector3(1.3f, transform.position.y, transform.position.z);
        Vector3 leftPos = new Vector3(-2f, transform.position.y, transform.position.z);

        if (isGameOver == false)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.deltaPosition.x > 50.0f)
                {
                    left = false;
                    right = true;
                }

                if (touch.deltaPosition.x < -50.0f)
                {
                    left = true;
                    right = false;
                }

                if (touch.deltaPosition.y > 50.0f)
                {
                    int jump_type = Random.Range(0, 4);

                    if (isOnGround == true)
                    {
                        if (jump_type == 1)
                        {
                            rb.velocity = Vector3.zero;
                            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                            Anim.SetInteger("isJumping", 1);
                            Anim.SetTrigger("Jump_trig");
                            isOnGround = false;
                            soundAudio.PlayOneShot(jumpAudio, 1.0f);
                        }
                        else if (jump_type == 2)
                        {
                            rb.velocity = Vector3.zero;
                            Anim.SetInteger("isJumping", 2);
                            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                            Anim.SetTrigger("Jump_trig");
                            isOnGround = false;
                            soundAudio.PlayOneShot(jumpAudio, 1.0f);
                        }
                        else if (jump_type == 3)
                        {
                            rb.velocity = Vector3.zero;
                            Anim.SetInteger("isJumping", 3);
                            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                            Anim.SetTrigger("Jump_trig");
                            isOnGround = false;
                            soundAudio.PlayOneShot(jumpAudio, 1.0f);
                        }

                    }

                }


                if (right == true)
                {
                    transform.position = Vector3.Lerp(transform.position, rightPos, 3 * Time.deltaTime);
                }
                if (left == true)
                {
                    transform.position = Vector3.Lerp(transform.position, leftPos, 3 * Time.deltaTime);
                }
            }
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    //CANCEL JUMP FUNCTION
    void Cancel_Jump()
    {
        Anim.SetBool("bool_Jump", false);
    }


    // COLLISON FUNCTION
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Health.health -= 1;
            crash_Particle.Play();
            Anim.SetBool("Death", true);
            Anim.SetInteger("Death_Int", 1);
            isGameOver = true;
            soundAudio.PlayOneShot(crashAudio, 1.0f);


            StartCoroutine(GameOverCountdownRoutine());

        }
    }

    // FUNCTION MADE IN A CERTAIN TIME INTERVAL.
    IEnumerator GameOverCountdownRoutine()
    {
        yield return new WaitForSecondsRealtime(4f);

        if (Health.health == 2)
        {
            if (SelectMap.selected_Map == 0)
            {
                PlayerPrefs.SetInt("health", Health.health);
                PlayerPrefs.SetInt("star", star_point);
                PlayerPrefs.SetInt("point", point);
                SceneManager.LoadScene(2);
                isGameActive = false;
            }

            if (SelectMap.selected_Map == 1)
            {
                PlayerPrefs.SetInt("health", Health.health);
                PlayerPrefs.SetInt("star", star_point);
                PlayerPrefs.SetInt("point", point);
                SceneManager.LoadScene(3);
                isGameActive = false;
            }

        }

        if (Health.health == 1)
        {
            if (SelectMap.selected_Map == 0)
            {
                PlayerPrefs.SetInt("health", Health.health);
                PlayerPrefs.SetInt("star", star_point);
                PlayerPrefs.SetInt("point", point);
                SceneManager.LoadScene(2);
                isGameActive = false;
            }
            if (SelectMap.selected_Map == 1)
            {
                PlayerPrefs.SetInt("health", Health.health);
                PlayerPrefs.SetInt("star", star_point);
                PlayerPrefs.SetInt("point", point);
                SceneManager.LoadScene(3);
                isGameActive = false;
            }

        }

        if (Health.health <= 0)
        {
            GameOverScreen.SetActive(true);
            Time.timeScale = 0f;
            Health.health = 3;
            isGameActive = false;

            if (Health.health == 3 && isGameActive == true)
            {
                star_point = 0;
                point = 0;
            }
        }
    }
}
