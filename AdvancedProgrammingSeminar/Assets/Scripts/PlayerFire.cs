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
		if(Input.GetMouseButtonDown(0) && Input.GetMouseButton(1)){
			this.gameObject.GetComponent<FishScript>().crimeLevel += 20f;
			Instantiate(objFire, ironSights.transform.position, ironSights.transform.rotation);
		}
	}
}
