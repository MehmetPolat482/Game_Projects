using System.Security.Cryptography;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject platform;
    public float angleStep;
    public int platformAmount;

    public float platformHeight;

    [Range(0 , 100)]
    public int badObstacleCount;

    public Material goodMaterial;
    public Material badMaterial;

    private void Awake()
    {
        Clean();
    }
    private void Start()
    {
        GenerateLevel();
    }

    [ContextMenu("GenerateLevel")]
    public void GenerateLevel()
    {
        for (int i= 0; i < platformAmount; i++)
        {
            var newObj = Instantiate(platform , Vector3.up * -platformHeight * i, Quaternion.Euler(0 ,angleStep * i , 0) , transform);

            int childCount = newObj.transform.childCount;
            for (int j = childCount - 1; j >= 0; j--)
            {
                var child = newObj.transform.GetChild(j).gameObject;
                child.tag = "Good";
                child.GetComponent<Renderer>().sharedMaterial = goodMaterial;
            }

            if (Random.Range(0 , 100) < badObstacleCount)
            {
                int randChild = Random.Range(0 , childCount);

                for (int j = childCount - 1; j >= 0; j--)
                {
                    if (j == randChild)
                    {
                        continue;
                    }
                    var child = newObj.transform.GetChild(j).gameObject;
                    child.tag = "Bad";
                    child.GetComponent<Renderer>().sharedMaterial = badMaterial;
                }
            }
        }
    }

    [ContextMenu("Random Number")]
    public void RandomNumber()
    {
        int rand = Random.Range(0 , 10);
    }
}
