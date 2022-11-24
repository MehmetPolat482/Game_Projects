using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeToBack : MonoBehaviour
{
    [Header("COUNT LABEL")]
    public GameObject countLabel;  // Decreasing time system at the beginning of the game for start the game

    [Header("AUDIO SOURCES")]
    public AudioSource goSound; //  Game start sound
    public AudioSource ReadySound; //  Game prep sound



    void Start()
    {
        StepDistance.dis = true;
        StartCoroutine(CountDown());
    }

    //Time Decreased Initiation System Function
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(0.03f);
        countLabel.GetComponent<TextMeshProUGUI>().text = "4";
        ReadySound.Play();
        CharacterController.isGameOver = true;
        countLabel.SetActive(true);

        yield return new WaitForSeconds(1);
        countLabel.SetActive(false);
        countLabel.GetComponent<TextMeshProUGUI>().text = "3";
        ReadySound.Play();
        CharacterController.isGameOver = true;
        countLabel.SetActive(true);

        yield return new WaitForSeconds(1);
        countLabel.SetActive(false);
        countLabel.GetComponent<TextMeshProUGUI>().text = "2";
        ReadySound.Play();
        CharacterController.isGameOver = true;
        countLabel.SetActive(true);

        yield return new WaitForSeconds(1);
        countLabel.SetActive(false);
        countLabel.GetComponent<TextMeshProUGUI>().text = "1";
        ReadySound.Play();
        CharacterController.isGameOver = true;
        countLabel.SetActive(true);

        yield return new WaitForSeconds(1);
        countLabel.SetActive(false);
        countLabel.GetComponent<TextMeshProUGUI>().text = "GO";
        goSound.Play();
        CharacterController.Anim.SetTrigger("Go_Ready");
        CharacterController.isGameOver = false;
        countLabel.SetActive(true);

        CharacterController.Anim.SetTrigger("Run_Ready");
        yield return new WaitForSeconds(1);
        countLabel.SetActive(false);
        StepDistance.dis = false;

    }
}
