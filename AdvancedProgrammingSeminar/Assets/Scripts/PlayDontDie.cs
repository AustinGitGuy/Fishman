using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDontDie : MonoBehaviour {

	bool play;

	public void Play(){
		if(!play){
			play = true;
			GetComponent<ParticleSystem>().Play();
		}
	}
}
