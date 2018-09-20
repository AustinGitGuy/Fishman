using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour {

	public string color;
	bool playerGotCard;

	void Start(){
		
	}
	
	void Update(){
		if(GetComponent<GuardScript>().dead && !playerGotCard){
			if(color == "Red"){
				Debug.Log("Player got red card");
				Managers.PlayerManager.Instance.redNum++;
				playerGotCard = true;
			}
			if(color == "Blue"){
				Debug.Log("Player got blue card");
                Managers.PlayerManager.Instance.blueNum++;
				playerGotCard = true;
			}
			if(color == "Green"){
				Debug.Log("Player got green card");
				Managers.PlayerManager.Instance.greenNum++;
				playerGotCard = true;
			}
		}
	}
}
