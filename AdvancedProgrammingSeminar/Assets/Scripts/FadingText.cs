using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingText : MonoBehaviour {

	//😊😊
	TextMesh text;

	void Start(){
		text = GetComponent<TextMesh>();
	}

	public void FadeIn(){
		if(text.color.a < 1){
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + .02f);
		}
	}

	public void FadeOut(){
		if(text.color.a > 0){
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - .02f);
		}
	}

	public void TurnOff(){
		text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
	}
}
