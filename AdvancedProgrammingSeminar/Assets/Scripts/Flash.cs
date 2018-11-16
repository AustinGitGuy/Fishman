using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour {

	SpriteRenderer sprite;
	Text textObj;
	[SerializeField]
	bool text;

	void Start(){
		if(text){
			textObj = GetComponent<Text>();
		}
		else {
			sprite = GetComponent<SpriteRenderer>();
		}
		InvokeRepeating("FlashObj", Time.deltaTime, .5f);
	}

	void FlashObj(){
		if(text){
			textObj.enabled = !textObj.enabled;
		}
		else {
			sprite.enabled = !sprite.enabled;
		}
	}
}
