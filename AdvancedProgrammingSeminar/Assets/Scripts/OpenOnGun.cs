using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOnGun : MonoBehaviour {

	PlayerFire gun;
	[SerializeField]
	bool vertical;
	[SerializeField]
	int questNum;
	bool open;

	void Start(){
		gun = Managers.PlayerManager.Instance.GetPlayer().GetComponent<PlayerFire>();
	}
	
	void Update(){
		if(!open && !gun.hasGun){
			OpenDoor();
		}
		if(open && gun.hasGun){
			CloseDoor();
		}
	}

	void OpenDoor(){
		open = true;
		if(vertical){
            transform.position = new Vector2(transform.position.x, transform.position.y + 2);
		}
        else {
            transform.position = new Vector2(transform.position.x - 2, transform.position.y);
        }
	}

	void CloseDoor(){
		open = false;
		if(vertical){
            transform.position = new Vector2(transform.position.x, transform.position.y - 2);
		}
        else {
            transform.position = new Vector2(transform.position.x + 2, transform.position.y);
        }
	}
}
