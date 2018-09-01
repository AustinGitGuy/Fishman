using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

	public GameObject text;
	public bool dead;

	void Start(){
		text = transform.Find("Desc").gameObject;
		text.SetActive(false);
	}

	void Update(){
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Projectile"){
			if(!dead) DeathSequence();
		}
	}

	void DeathSequence(){
		dead = true;
		transform.Rotate(new Vector3(90f, 0f, 0f));
		transform.position = new Vector3(transform.position.x, transform.position.y - .6f, transform.position.z);
	}
}
