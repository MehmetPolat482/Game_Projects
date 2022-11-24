using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylController : MonoBehaviour
{
    public List<Cylinder> cylList = new List<Cylinder>();
    public Cylinder currentCyl;
    public Transform spawnPoint;

    private int speed = 25;
    private Touch touch;
    private Vector3 downPos, upPos;
    private bool dragStarted;
    // Start is called before the first frame update
    void Start()
    {
        currentCyl = PickRandomCyl();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                dragStarted = true;
                downPos = touch.position;
                upPos = touch.position;
            }
            if (dragStarted)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    downPos = touch.position;
                }
                if (currentCyl)
                {
                    currentCyl.rb.velocity = CalculateDirection() * 10;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    dragStarted = false;
                    downPos = touch.position;

                    currentCyl.rb.velocity = new Vector3(0, 0, speed);

                    StartCoroutine(SetCyl());
                }
            }
        }
    }
    private IEnumerator SetCyl()
    {
        yield return new WaitForSeconds(2);
        currentCyl = PickRandomCyl();
    }
    private Cylinder PickRandomCyl()
    {
        GameObject temp = Instantiate(cylList[Random.Range(0, cylList.Count)].gameObject, spawnPoint.position, Quaternion.identity);
        return temp.GetComponent<Cylinder>();
    }
    private Vector3 CalculateDirection()
    {
        Vector3 temp = (downPos - upPos).normalized;
        temp.y = temp.x;
        temp.z = 0;
        temp.y = 0;

        return temp;
    }
}
