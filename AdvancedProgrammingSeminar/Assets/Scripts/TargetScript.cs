using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

	public GameObject text;
	public int id;

<<<<<<< HEAD
	void Start(){
=======
	GuardScript guard;

	ParticleSystem pS;

	void Start(){
		pS = GetComponent<ParticleSystem>();
		guard = GetComponent<GuardScript>();
>>>>>>> a4e04b1c5ccf3fec7e21069d0837a035e5217077
		if(!text){
			text = transform.Find("Desc").gameObject;
		}
		text.SetActive(false);
	}

<<<<<<< HEAD
=======
	void Update(){
		if(guard.dead){
			pS.Stop();
		}
	}

>>>>>>> a4e04b1c5ccf3fec7e21069d0837a035e5217077
}
