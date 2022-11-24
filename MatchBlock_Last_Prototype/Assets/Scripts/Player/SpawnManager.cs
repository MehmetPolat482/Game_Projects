using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //LIST OF SPAWNOBJECT TRANSFORM POSITION
    public List<Transform> spwnList = new List<Transform>();  

    //LIST OF SPAWNOBJECTS
    public List<CubeNumbers> cubeList = new List<CubeNumbers>();  
    // Start is called before the first frame update
    void Start()
    {
        PickRandomCube();
    }

    //Randomly spawned numbers function
    private void PickRandomCube()
    {
        for (int i = 0; i < spwnList.Count; i++)
        {
            Instantiate(cubeList[Random.Range(0, cubeList.Count)].gameObject, spwnList[i].position, spwnList[i].rotation);
        }

    }
}
