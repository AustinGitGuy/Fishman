using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

	GameObject colliding;

	void Start(){
		
	}
	
	void Update(){
		CheckAttack();
	}

	void CheckAttack(){
		if(Input.GetMouseButtonDown(0)){
			if(colliding != null){
				if(colliding.tag == "Target" || colliding.tag == "Civilian" || colliding.tag == "Guard"){
					if(!colliding.GetComponent<GuardScript>().dead){
						StartCoroutine(KillSomething());
					}
				}
			}
		}
	}

	IEnumerator KillSomething(){
		colliding.GetComponent<GuardScript>().DeathSequence();
		yield return new WaitForSeconds(.5f);
	}

	void OnCollision2DEnter(Collision2D col){
		colliding = col.gameObject;
	}

	void OnCollision2DExit(Collision2D col){
		colliding = null;
	}
}
