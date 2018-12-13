using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlightlyShake : MonoBehaviour {

	Vector3 startPos;

	void Start(){
		startPos = transform.position;
	}
	
	void Update(){
<<<<<<< HEAD
		if(Vector2.Distance(startPos, transform.position) >= .1){
			transform.position = startPos;
		}
		iTween.ShakePosition(this.gameObject, new Vector3(.005f, 0f, 0f), Time.deltaTime);
=======
		iTween.ShakePosition(this.gameObject, new Vector3(.009f, 0f, 0f), Time.deltaTime);
>>>>>>> a4e04b1c5ccf3fec7e21069d0837a035e5217077
	}
}
