using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
	//Oyundaki Değişkenler
	public Vector3 startPos;
	private float repeatwidth;
   
   //ArkaPlanın Bir Loopa Girmesi Sağlanması
    void Start()
    {
		startPos =transform.position;
		repeatwidth = GetComponent<BoxCollider>().size.x / 2 ;
        
    }

   //ArkaPlanın Ne Kadar Sürede Loopa Girmesi Belirtilmesi
    void Update()
    {
        if(transform.position.x < startPos.x - repeatwidth){
			transform.position = startPos ;
			
		}
    }
}
