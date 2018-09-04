using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVehicle : MonoBehaviour {

	GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update(){
		if(!Managers.PlayerManager.Instance.cutscene){
			this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -5);
		}
	}
}
