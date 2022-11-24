using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro ;

public class RaceManager : MonoBehaviour
{
	[Header("GameObject")]
	[SerializeField] private GameObject Cp ;
	[SerializeField] private GameObject CheckpointHolder ;
	[Header("Players")]
	[SerializeField] private GameObject[] Players ;
	[Header("Checkpoints")]
	[SerializeField] private Transform[] CheckpointPositions;
	[Header("CheckpointForEachPlayers")]
	[SerializeField] private GameObject[] CheckpointForEachPlayer ;
	
	[Header("Total Player and Checkpoint")]
	private int totalPlayer;
	private int totalCheckpoint;
	
	[Header("Rank Text")]
	[SerializeField] private TextMeshProUGUI PositionTxt ;
    // Start is called before the first frame update
    void Start()
    {
        totalPlayer = Players.Length;
		totalCheckpoint =CheckpointHolder.transform.childCount;
		
		SetCheckpoint();
		SetPlayerPosition();
    }
	void SetCheckpoint(){
		CheckpointPositions = new Transform [totalCheckpoint];
		
		for(int i=0 ; i < totalCheckpoint ; i++){
			CheckpointPositions[i] = CheckpointHolder.transform.GetChild(i).transform;
		}
		
		CheckpointForEachPlayer = new GameObject[totalPlayer];
		
		for(int i=0 ; i < totalPlayer ; i++){
			CheckpointForEachPlayer[i] = Instantiate(Cp , CheckpointPositions[0].position , CheckpointPositions[0].rotation );
			CheckpointForEachPlayer[i].name = "CP" + i;
			CheckpointForEachPlayer[i].layer = 6 + i;
		}
	}
	void SetPlayerPosition(){
		for(int i=0 ; i < totalPlayer ; i++){
			Players[i].GetComponent<PlayerCpManager>().playerPosition = i +1;
			Players[i].GetComponent<PlayerCpManager>().playerNumber = i;
		}
		
		PositionTxt.text = Players[0].GetComponent<PlayerCpManager>().playerPosition +"/"+ totalPlayer ; //The player's urrent rank show in real time at the top left corner of the screen. 
	}
	
	public void PlayerCollectedCp(int playerNumber , int cpNumber){
		CheckpointForEachPlayer[playerNumber].transform.position = CheckpointPositions[cpNumber].transform.position; 
		
		comparePosition(playerNumber);
	}
	void comparePosition(int playerNumber){
		if(Players[playerNumber].GetComponent<PlayerCpManager>().playerPosition > 1){
			GameObject currentPlayer = Players[playerNumber];
			int currentPlayerPos = currentPlayer.GetComponent<PlayerCpManager>().playerPosition;
			int currentPlayerCp = currentPlayer.GetComponent<PlayerCpManager>().cpCrossed;
			
			GameObject playerInFront = null;
			int playerInFrontPos = 0;
			int playerInFrontCp = 0;
			
			for(int i=0 ; i < totalPlayer ; i++){
				if(Players[i].GetComponent<PlayerCpManager>().playerPosition == currentPlayerPos - 1){
					
					playerInFront = Players[i];
					playerInFrontCp = playerInFront.GetComponent<PlayerCpManager>().cpCrossed;
					playerInFrontPos = playerInFront.GetComponent<PlayerCpManager>().playerPosition;
					break;	
				}
			}
			if(currentPlayerCp > playerInFrontCp){
				currentPlayer.GetComponent<PlayerCpManager>().playerPosition = currentPlayerPos - 1 ;
				playerInFront.GetComponent<PlayerCpManager>().playerPosition = playerInFrontPos + 1 ;
			}
			PositionTxt.text = Players[0].GetComponent<PlayerCpManager>().playerPosition +"/"+ totalPlayer ; //The player's urrent rank show in real time at the top left corner of the screen. 
		}
	}
}
