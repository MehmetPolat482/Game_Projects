using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("List of Spawn Object Transform")]
    public List<Transform> spwnList = new List<Transform>();  //Object's Transform in the game

    [Header("List of Spawn Object")]
    public List<Cylinder> cylList = new List<Cylinder>();   //Object's List in the game
    // Start is called before the first frame update
    void Start()
    {
        PickRandomCyl();
    }

    //Randomly spawned numbers function
    private void PickRandomCyl()
    {
        for (int i = 0; i < spwnList.Count; i++)
        {
            Instantiate(cylList[Random.Range(0, cylList.Count)].gameObject, spwnList[i].position, Quaternion.identity);
        }

    }
}
