using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectObject : MonoBehaviour {

	GameObject player;
	FadingText text;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
		text = transform.Find("Desc").GetComponent<FadingText>();
		text.TurnOff();
	}
	
	void Update(){
		if(Vector2.Distance(player.transform.position, this.transform.position) <= 3 && Input.GetKeyDown(KeyCode.E)){
			text.FadeIn();
		}
		else {
			text.FadeOut();
		}
	}
}
