using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCpManager : MonoBehaviour
{
   [Header("PlayerNumber")]
	public int playerNumber ;
   [Header("Checkpoint Cross")]
   public int cpCrossed = 0;
   [Header("Player Position")]
   public int playerPosition;
    [Header("Race Manager")]
   [SerializeField] private RaceManager raceManager;
   
   //What happens when the character and opponents hits the Checkpoints.
   private void OnTriggerEnter(Collider other){
	   
	   if(other.gameObject.CompareTag("CP")){
		   
		   cpCrossed += 1;
		   
		   raceManager.PlayerCollectedCp(playerNumber , cpCrossed);
	   }
   }
}
