using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
   
    private float width; 
  

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    

        width = boxCollider2D.size.x;
    }
   
    public void Background()
    {
        Vector2 vector = new Vector2(width/2 , 0);
        transform.position = (Vector2)transform.position + vector;
    }

}
