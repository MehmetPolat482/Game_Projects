using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //LIST OF THE CUBES
    public List<CubeNumbers> cubeList = new List<CubeNumbers>(); 

    // CUBE VARIABLES
    private CubeNumbers currentCube;  
    public Transform spawnPoint; 

    //TOUCH CONTROLLER
    private Touch touch;     
    private Vector3 downPos, upPos; 
    public static bool isTrigger = false;  

    //BOOL SYSTEM
    private bool isThrowed = false;
    private bool isDragged = true;

    // Start is called before the first frame update
    void Start()
    {
       
            currentCube = PickRandomCube();

    }
    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
          
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                downPos = touch.position;
                upPos = touch.position;
                isDragged = true;
            }

            if (isDragged)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    downPos = touch.position;
                }

                if (currentCube)
                {
                    currentCube.rb.velocity = CalculateDirection() * 5;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    downPos = touch.position;
                    if (!currentCube) return;
                    currentCube.rb.velocity = Vector3.zero;
                    currentCube.SendCube();
                    isThrowed = true;
                    isDragged = false;


                    if (isThrowed == true)
                    {
                        StartCoroutine(SetCube());
                    }
                }
             
            }

        }

    }

    private IEnumerator SetCube()
    {
        yield return new WaitForSeconds(4);
        currentCube = PickRandomCube();
    }

    // A Function That Displays The Spawning Of Cylinders At Random Intervals
    private CubeNumbers PickRandomCube()
    {
        GameObject temp = Instantiate(cubeList[Random.Range(0, cubeList.Count)].gameObject, spawnPoint.transform.position, spawnPoint.transform.rotation);
        return temp.GetComponent<CubeNumbers>();
    }

    // 
    private Vector3 CalculateDirection()
    {
        Vector3 temp = (downPos - upPos).normalized;
        temp.y = temp.x;
        temp.z = 0;
        temp.y = 0;

        return temp;
    }
}
