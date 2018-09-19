using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

	GameObject player;
	public GameObject door;
	public bool vertical;
	public string color;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
	}
	
	void Update(){
		if(Vector2.Distance(player.transform.position, this.transform.position) <= 3){
			if(Input.GetKeyDown(KeyCode.E)){
				if(color == "Red"){
					if(Managers.PlayerManager.Instance.redGot){
						door.transform.position = new Vector2(door.transform.position.x, door.transform.position.y + 2);
						Managers.PlayerManager.Instance.redGot = false;
					}
				}
				if(color == "Blue"){
					if(Managers.PlayerManager.Instance.blueGot){
						door.transform.position = new Vector2(door.transform.position.x, door.transform.position.y + 2);
						Managers.PlayerManager.Instance.blueGot = false;
					}
				}
				if(color == "Green"){
					if(Managers.PlayerManager.Instance.greenGot){
						door.transform.position = new Vector2(door.transform.position.x, door.transform.position.y + 2);
						Managers.PlayerManager.Instance.greenGot = false;
					}
				}
			}
		}
	}
}
