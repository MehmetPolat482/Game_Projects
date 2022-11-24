using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWall : MonoBehaviour
{
    int colorValue;
    [SerializeField] private Constants.CubeColors myColor;
    private Renderer rend;
    // Start is called before the first frame update

    [SerializeField] private List<Material> materialList = new List<Material>();

    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
        SetColor(myColor);
    }

    public void SetColor(Constants.CubeColors cc)
    {
       ColorSystem();

    }

    public Constants.CubeColors GetColor() => myColor;

    public void ColorSystem()
    {
        int materialIndex = Random.Range(1, (materialList.Count - 1));
        rend.material = materialList[materialIndex];
    }

}
