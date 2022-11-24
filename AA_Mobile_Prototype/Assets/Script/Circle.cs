using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Circle : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public bool isMoved;

    public LineRenderer line;

    Transform sphere;

    float speed = 20.0f;

    GameManager gameManager;

    public CircleCollider2D circleCollider2D;

    private void Start()
    {
        sphere = GameObject.FindGameObjectWithTag("MainBall").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        MovementBall();
    }

    public void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Ball")
        {
            GameManager.isLosed = true;
        }
    }

    public void MovementBall()
    {
        if(isMoved == true)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            circleCollider2D.enabled = true;
        }

        float distance = Vector3.Distance(transform.position, sphere.position);

        if (distance <= 2.2f)
        {
            isMoved = false;

            line.SetPosition(0 , new Vector3(0 , 3 , 0));
            transform.parent = sphere.transform;
        }

    }
}
