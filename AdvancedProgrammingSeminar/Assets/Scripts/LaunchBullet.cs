using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBullet : MonoBehaviour {

	Rigidbody2D rb;
	float forceAmount = 500f;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		rb.AddRelativeForce(Vector3.forward * forceAmount);
		Destroy(this.gameObject, 10f);
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Target"){
			Destroy(this.gameObject);
		} 
		else {
			Destroy(this.gameObject, 2f);
		}
	}
}
