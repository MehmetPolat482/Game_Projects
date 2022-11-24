using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Obstacle[] obstacle;

    public float rotationSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void ShatterAllObstacle()
    {
        if(transform.parent == null)
        {
            transform.parent = null;
        }

        foreach (Obstacle item in obstacle)
        {
            item.Shatter();
        }

        StartCoroutine(ShatterTimeSystem());
    }

    IEnumerator ShatterTimeSystem()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
