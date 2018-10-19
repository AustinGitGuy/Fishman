using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterShake : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		StartCoroutine(Shake());
	}

	IEnumerator Shake(){
		transform.position = new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z);
		yield return new WaitForSeconds(.1f);
		transform.position = new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z);
	}
}
