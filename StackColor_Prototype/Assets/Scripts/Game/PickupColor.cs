using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupColor : MonoBehaviour
{

    int colorValue;
    [SerializeField] private Constants.CubeColors myColor;
    private Renderer rend;
    // Start is called before the first frame update

 [SerializeField] private Material[] materialList;

    
    void Start()
    {
        rend = GetComponent<Renderer>();
        SetColor(myColor);
    }

    public void SetColor(Constants.CubeColors cc) {
        colorValue = (int)cc;
        rend.material = materialList[colorValue];
        
    }

    public Constants.CubeColors GetColor() => myColor;

}
