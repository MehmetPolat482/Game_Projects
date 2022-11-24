using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public  int value;

    public GameObject nextCyl;

    public Rigidbody rb;
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        ID = GetInstanceID();
        rb = GetComponent<Rigidbody>();


    }
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
