using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

	public GameObject text;
	public int id;

	GuardScript guard;

	ParticleSystem pS;

	void Start(){
		pS = GetComponent<ParticleSystem>();
		guard = GetComponent<GuardScript>();
		if(!text){
			text = transform.Find("Desc").gameObject;
		}
		text.SetActive(false);
	}

	void Update(){
		if(guard.dead){
			pS.Stop();
		}
	}

}
