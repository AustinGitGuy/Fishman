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
		if(Vector2.Distance(player.transform.position, this.transform.position) <= 4){
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
