using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    //SPEED
    [SerializeField] private float speed;

    //TRABSFORM
    [SerializeField] private Transform target;
    //GAMEOBJECT PREFABS
    [SerializeField] private GameObject _coinPrefab;

    // CAMERA
    [SerializeField] private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    public void StartCoinMoving(Vector3 initial)
    {
        //Vector3 initialPos = camera.ScreenToViewportPoint(new Vector3(initial.position.x, initial.position.y, initial.position.z  * - 1));
        Vector3 targetPos = cam.ScreenToViewportPoint(new Vector3(target.position.x, target.position.y, target.position.z  * - 1));

        GameObject _coinn = Instantiate(_coinPrefab , transform);

        StartCoroutine(MoveCoin(_coinn.transform , initial ,targetPos));
    }

    IEnumerator MoveCoin(Transform obj, Vector3 startPos, Vector3 endPos)
    {
        float time = 0;

        while (time < 1)
        {
            time += speed * Time.deltaTime;

            obj.position = Vector3.Lerp(startPos, endPos, time);


            yield return new WaitForEndOfFrame();
        }
        yield return null;

        Destroy(obj.gameObject);
    }
}
