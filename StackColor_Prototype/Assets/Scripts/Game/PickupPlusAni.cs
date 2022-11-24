using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPlusAni : MonoBehaviour
{
    public Canvas goldPlus;
    public Transform pickup;
    // Start is called before the first frame update
    void Start()
    {
      

        pickup.transform.position = goldPlus.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
         

            goldPlus.transform.position = pickup.transform.position;
        }
    }
}
