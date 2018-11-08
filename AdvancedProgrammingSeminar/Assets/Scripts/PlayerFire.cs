using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

	public GameObject objFire;
	GameObject particles;
	public bool hasGun;

	void Start(){
		particles = transform.Find("Particles").gameObject;
	}

	void Update(){
		Fire();
	}

	void Fire(){
		if(Input.GetMouseButtonDown(1) && hasGun){
			Vector3 ironSightsPos = transform.position;
			RaycastHit2D[] sight = Physics2D.RaycastAll(ironSightsPos, transform.up, 1);
			Debug.DrawRay(ironSightsPos, transform.right, Color.red);
			foreach(RaycastHit2D hit in sight){
				if(hit.transform.gameObject.tag == "Blockable"){
					return;
				}
			}
			Managers.NPCManager.Instance.SendNoise(0f, 20f);
			Instantiate(objFire, ironSightsPos, new Quaternion(0, 0, 0, 0));
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.name == "Gun" && Vector2.Distance(col.transform.position, this.transform.position) <= 2){
			particles.GetComponent<PlayDontDie>().Play();
			hasGun = true;
			col.gameObject.SetActive(false);
		}
	}
}
