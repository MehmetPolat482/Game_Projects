using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeWall : MonoBehaviour
{
	[Header("Material")]
	[SerializeField] private Material myMaterial;
	[Header("Mesh Renderer")]
	[SerializeField] private MeshRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend=GetComponent<MeshRenderer>();  //We can manipulate mesh renderer with GetComponent.
		rend.enabled = true;
    }

	void Update(){
		
		 if(Input.touchCount > 0){
			 
			 Touch finger = Input.GetTouch(0);
			  
			if(finger.phase == TouchPhase.Began){
				 ChangeColor();
			}
		 }
	}
	
	//Wall is painted red when touching the screen
	void ChangeColor(){
		rend.material.color = Color.red;
	}
}
