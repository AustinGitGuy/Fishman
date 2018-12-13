using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	public Transform target;
	GameObject[] clients;

	void Start(){
		clients = GameObject.FindGameObjectsWithTag("Client");
	}

	void Update(){
		if(target == null){
			target = GetClosestClient(clients);
			if(target.gameObject.GetComponent<GiveMission>().targetDead){
				target = null;
				return;
			}
		}
		Vector3 dir = target.position - transform.position;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
	}

	//https://forum.unity.com/threads/clean-est-way-to-find-nearest-object-of-many-c.44315/
	Transform GetClosestClient(GameObject[] clients){
    	Transform tMin = null;
    	float minDist = Mathf.Infinity;
    	Vector3 currentPos = transform.position;
    	foreach (GameObject t in clients){
        	float dist = Vector3.Distance(t.transform.position, currentPos);
        	if (dist < minDist){
        	    tMin = t.transform;
        	    minDist = dist;
        	}
    	}
    	return tMin;
	}
}
