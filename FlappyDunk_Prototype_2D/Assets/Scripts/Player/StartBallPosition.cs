using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBallPosition : SelectManager
{
    public Transform startPos;


    // Start is called before the first frame update
    void Start()
    {
        StartBall();
    }

  
    public void StartBall()
    {

        for (int i=0; i < Balls.Length; i++)
        {
          

            if (i == selected_Ball)
            {
                Balls[i].SetActive(true);
            }
        }
            
    }
}
