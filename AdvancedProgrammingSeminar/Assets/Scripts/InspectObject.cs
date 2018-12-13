using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectObject : MonoBehaviour {

	GameObject player;
	FadingText text;
	bool inspecting;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
		text = transform.Find("Desc").GetComponent<FadingText>();
		text.TurnOff();
	}
	
	void Update(){
<<<<<<< HEAD
		if(Vector2.Distance(player.transform.position, this.transform.position) <= 3){
=======
		if(Vector2.Distance(player.transform.position, this.transform.position) <= 4){
>>>>>>> a4e04b1c5ccf3fec7e21069d0837a035e5217077
			if(Input.GetKeyDown(KeyCode.E) || inspecting){
				inspecting = true;
				text.FadeIn();
			}
		}
		else {
			inspecting = false;
			text.FadeOut();
		}
	}
}
