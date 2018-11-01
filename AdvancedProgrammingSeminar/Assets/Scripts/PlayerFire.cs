using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

	GameObject ironSights;
	public GameObject objFire;
	public bool hasGun;

	void Start(){
		ironSights = transform.Find("IronSights").gameObject;
	}

	void Update(){
		Fire();
	}

	void Fire(){
		if(Input.GetMouseButtonDown(1) && hasGun){
			Vector3 ironSightsPos = ironSights.transform.position;
			RaycastHit2D[] sight = Physics2D.RaycastAll(ironSightsPos, transform.up, 1);
			Debug.DrawRay(ironSightsPos, transform.right, Color.red);
			foreach(RaycastHit2D hit in sight){
				if(hit.transform.gameObject.tag == "Blockable"){
					return;
				}
			}
			this.gameObject.GetComponent<FishScript>().crimeLevel += 20f;
			Instantiate(objFire, ironSightsPos, new Quaternion(0, 0, 0, 0));
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.name == "Gun" && Vector2.Distance(col.transform.position, this.transform.position) <= 2){
			hasGun = true;
			Destroy(col.gameObject);
		}
	}
}
