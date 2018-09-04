using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour {

	public float xWalk;
	public float yWalk;
	public bool lineWalk = true;
	bool forward;
	Vector3[] points;

	void Start(){
		if(lineWalk){
			points = new Vector3[2];
			points[0] = new Vector3(transform.position.x + xWalk, transform.position.y + yWalk, transform.position.z);
			points[1] = new Vector3(transform.position.x - xWalk, transform.position.y - yWalk, transform.position.z);
		}
	}

	void Update(){
		if(lineWalk){
			LineWalk();
		}
	}

	void LineWalk(){
		if(GetComponent<GuardScript>().dead){
			return;
		}
		if(!forward){
			Vector3 newPos = points[0];
			Vector3 dir = newPos - transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.position = Vector2.MoveTowards(transform.position, points[0], Time.deltaTime);
			if(transform.position == newPos){
				forward = true;
			}
		}
		else {
			Vector3 newPos = points[1];
			Vector3 dir = newPos - transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.position = Vector2.MoveTowards(transform.position, points[1], Time.deltaTime);
			if(transform.position == newPos){
				forward = false;
			}
		}
	}
}
