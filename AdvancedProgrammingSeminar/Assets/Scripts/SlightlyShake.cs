using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlightlyShake : MonoBehaviour {

	Vector3 startPos;

	void Start(){
		startPos = transform.position;
	}
	
	void Update(){
		if(Vector2.Distance(startPos, transform.position) >= .15){
			transform.position = startPos;
		}
		iTween.ShakePosition(this.gameObject, new Vector3(.009f, 0f, 0f), Time.deltaTime);
	}
}
