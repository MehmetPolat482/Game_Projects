using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //CHARACTER VALUABLES
    [Header("Character Movement Speed")]
    [SerializeField] private float _movementSpeed;
    Rigidbody _chRb;
    Transform _pickupParent;

    [SerializeField] private float distanceBetweenObject;
    [SerializeField] private Transform stackPos;
    [SerializeField] private Transform parent;

    //BOOL SYSTEM
    [SerializeField] public static bool isPlaying = false;
    [SerializeField] public bool left, right;


    // TRANSFORM SYSTEM
    [Header("TRANSFORMS")]
    public Transform ground1;      // Repeated path transform
    public Transform ground2;      // Repeated path transform


    //GAMEOBJECT START TEXT
    [SerializeField] private GameObject _startText;
    [SerializeField] private GameObject _coin;

    //COIN SYSTEM SCRIPT
    public CoinSystem coinSystem;

    //COIN COLLECT SYSTEM SCRIPT
    public CoinCollect coinCollect;

    LevelUpdate levelUpdate;
    SpawnManager spawnManager;

    public List<GameObject> gameObjectList = new List<GameObject>();

    //ANIMATOR
    public Animator ani;
    private List<PickupColor> cubeList = new List<PickupColor>();



    // Start is called before the first frame update
    public void Start()
    {
        _chRb = GetComponent<Rigidbody>();
        levelUpdate = GetComponent<LevelUpdate>();
        spawnManager = GetComponent<SpawnManager>();
        distanceBetweenObject = stackPos.localScale.y;
    }

    public void FixedUpdate()
    {

        if (Input.GetMouseButton(0))
        {
            isPlaying = true;
            ani.SetBool("Started", true);
            _startText.SetActive(false);
        }

        if (isPlaying == true)
        {
            Movement();
            Inputs();
        }
    }

    private void Movement()
    {
        _chRb.velocity = Vector3.forward * _movementSpeed;
    }

    private void Inputs()
    {
        Vector3 rightPos = new Vector3(1.3f, transform.position.y, transform.position.z);
        Vector3 leftPos = new Vector3(-1.3f, transform.position.y, transform.position.z);

        if (isPlaying == true)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.deltaPosition.x > 40.0f)
                {
                    left = false;
                    right = true;
                }

                if (touch.deltaPosition.x < -40.0f)
                {
                    left = true;
                    right = false;
                }


                if (right == true)
                {
                    transform.position = Vector3.Lerp(transform.position, rightPos, 3 * Time.deltaTime);
                }
                if (left == true)
                {
                    transform.position = Vector3.Lerp(transform.position, leftPos, 3 * Time.deltaTime);
                }
            }
            transform.Translate(0, 0, _movementSpeed * Time.deltaTime);
        }
    }


    // COLLIDER FUNCTION
    private void OnTriggerEnter(Collider other)
    {
        // REPEAT GROUND

        if (other.gameObject.name == "Start")
        {
            ground2.position = new Vector3(ground1.position.x, ground1.position.y, ground1.position.z + 50.0f);
        }
        if (other.gameObject.name == "Finish")
        {
            ground1.position = new Vector3(ground2.position.x, ground2.position.y, ground2.position.z + 50.0f);
        }


        // PICKUP STACKER
        if (other.tag == "Pickup_Ground")
        {

            Stack(other.gameObject, true);
            LevelUpdate.currentIndex += 5f;
            ani.SetBool("Stacked", true);

            coinCollect.StartCoinMoving(_coin.transform.position);
            coinSystem.ScoreUpdate(1);

            Rigidbody newRb = other.transform.GetComponent<Rigidbody>();
            newRb.isKinematic = true;
            other.enabled = false;
        }

        //COLOR WALL

        if (other.tag == "ColorWall")
        {
            print("change color");
            Constants.CubeColors cubeColor = other.GetComponent<ColorWall>().GetColor();
            ChangeCharacterColors(cubeColor);
            ChangeSpawnCubeColors(cubeColor);
            ChangeColors(cubeColor);
        }

    }

    public void Stack(GameObject pickupObject, bool downOrUp = true)
    {
        pickupObject.transform.parent = parent;
        Vector3 desPos = stackPos.localPosition;
        desPos.y += downOrUp ? distanceBetweenObject : -distanceBetweenObject;

        pickupObject.transform.localPosition = desPos;

        stackPos = pickupObject.transform;

        cubeList.Add(pickupObject.GetComponent<PickupColor>());
    }

    private void ChangeColors(Constants.CubeColors c)
    {
        for (int i = 0; i < cubeList.Count; i++)
        {
            cubeList[i].SetColor(c);
        }
    }

    private void ChangeSpawnCubeColors(Constants.CubeColors c)
    {

        spawnManager._pickupGround.GetComponent<PickupColor>().SetColor(c);
    }

    private void ChangeCharacterColors(Constants.CubeColors c)
    {
        foreach (GameObject item in gameObjectList)
        {

            item.GetComponent<PickupColor>().SetColor(c);

        }

    }

}
