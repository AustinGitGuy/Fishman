using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour {
	public List<Vector3> points;
	int curPoint = 0;
	Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
		Walk();
	}

	void Walk(){
		if(GetComponent<GuardScript>().dead){
			return;
		}

	}

	IEnumerator ToNextPoint(){
		yield return null;
	}
}
