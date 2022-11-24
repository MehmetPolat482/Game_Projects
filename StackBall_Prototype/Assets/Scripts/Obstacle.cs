using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody rb;
    MeshRenderer meshRenderer;
    MeshCollider meshCollider;
    ObstacleController obstacleController;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        obstacleController = transform.parent.GetComponent<ObstacleController>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shatter()
    {
        rb.isKinematic = false;
        meshCollider.enabled = false;

        Vector3 forcePosition = transform.parent.position;
        float parentXPos = transform.parent.position.x;
        float xPos = meshRenderer.bounds.center.x;

        Vector3 subDirection = (parentXPos - xPos < 0) ? Vector3.right : Vector3.left;

        Vector3 dir = (Vector3.up * 1.5f + subDirection).normalized;

        float force = Random.Range(20, 50);
        float torque = Random.Range(100, 150);

        rb.AddForceAtPosition(dir * force, forcePosition, ForceMode.Impulse);
        rb.AddTorque(Vector3.left * torque);
        rb.velocity = Vector3.down;
    }
}
