using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingText : MonoBehaviour {

	//😊😊
	TextMesh text;
<<<<<<< HEAD

	void Start(){
		text = GetComponent<TextMesh>();
=======
	SpriteRenderer border;
	public Transform borderObj;

	void Start(){
		text = GetComponent<TextMesh>();
		border = transform.Find("100x100Square").GetComponent<SpriteRenderer>();
>>>>>>> a4e04b1c5ccf3fec7e21069d0837a035e5217077
	}

	public void FadeIn(){
		if(text.color.a < 1){
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + .02f);
<<<<<<< HEAD
=======
			border.color = new Color(border.color.r, border.color.g, border.color.b, border.color.a + .02f);
>>>>>>> a4e04b1c5ccf3fec7e21069d0837a035e5217077
		}
	}

	public void FadeOut(){
		if(text.color.a > 0){
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - .02f);
<<<<<<< HEAD
=======
			border.color = new Color(border.color.r, border.color.g, border.color.b, border.color.a - .02f);
>>>>>>> a4e04b1c5ccf3fec7e21069d0837a035e5217077
		}
	}

	public void TurnOff(){
		//text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
	}
}
