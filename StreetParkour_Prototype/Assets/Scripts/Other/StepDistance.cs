using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StepDistance : MonoBehaviour
{

    [Header("STEP DISTANCE")]
    public GameObject disDisplay; // Step Distance GameObject

    [Header("NUMBER OF STEP")]
    public int disRun;      // Number of Step increasing over time in the game
    [Header("BOOL SYSTEM")]
    public bool addingDis = false; // Is the number of steps added or not?
    public static bool dis = false; // Is he stepping or not? or Is she stepping or not?

    // Update is called once per frame
    void Update()
    {
        if (dis == false)
        {
            if (addingDis == false)
            {
                addingDis = true;
                StartCoroutine(AddingDis());
            }
        }

    }
    IEnumerator AddingDis()
    {
        disRun += 1;
        disDisplay.GetComponent<TextMeshProUGUI>().text = "" + disRun + "M";
        yield return new WaitForSeconds(2f);
        addingDis = false;
    }
}
