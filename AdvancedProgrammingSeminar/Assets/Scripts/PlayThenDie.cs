using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayThenDie : MonoBehaviour {
	bool play;

	public void Play(){
		if(!play){
			play = true;
			GetComponent<ParticleSystem>().Play();
		}
		Destroy(this.gameObject, 1.5f);
	}
}
