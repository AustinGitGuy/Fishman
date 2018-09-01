using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

	GameObject ironSights;
	public GameObject objFire;

	void Start(){
		ironSights = transform.Find("IronSights").gameObject;
	}

	void Update(){
		Fire();
	}

	void Fire(){
		if(Input.GetKeyDown(KeyCode.E)){
			Instantiate(objFire, ironSights.transform.position, ironSights.transform.rotation);
		}
	}
}
