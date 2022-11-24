using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public List<Transform> spwnList = new List<Transform>();

    public List<Cylinder> cylList = new List<Cylinder>();
    // Start is called before the first frame update
    void Start()
    {
        PickRandomCyl();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PickRandomCyl()
    {
        for (int i = 0; i < spwnList.Count; i++)
        {
            Instantiate(cylList[Random.Range(0, cylList.Count)].gameObject, spwnList[i].position, Quaternion.identity);
        }

    }
}
