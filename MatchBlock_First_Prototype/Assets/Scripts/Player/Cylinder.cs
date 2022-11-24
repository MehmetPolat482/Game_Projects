using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    [Header("Value")]
    public int value;   // Cylinder's Value

    [Header("Next Cylinder")]
    public GameObject nextCyl;  // Next upcoming object

    [Header("Object's Rigidbody")]
    public Rigidbody rb;    // Rigidbody of the object in the game

    [Header("Object's ID")] // ID of the object in the game
    public int ID;

    public AudioSource sound_Cyl;
    // Start is called before the first frame update
    void Start()
    {
        ID = GetInstanceID();
        rb = GetComponent<Rigidbody>();


    }
    //Object function spawned during the game
    public void SendCyl()
    {
        rb.AddForce(-transform.right * 700);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cyl"))
        {
            if (collision.gameObject.TryGetComponent(out Cylinder Cyl))
            {
                sound_Cyl.Play();
                if (Cyl.value == value)
                {
                    if (ID < Cyl.ID) return;
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);

                    if (nextCyl != null)
                    {
                        GameObject temp = Instantiate(nextCyl, transform.position, Quaternion.identity);
                    }
                    Score.Instance.ScoreInt += Cyl.value;
                }
            }
        }
    }

}
