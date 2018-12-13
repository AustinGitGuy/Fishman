using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

	public GameObject objFire;
	GameObject particles;
	public bool hasGun;
	bool cooldown;

	void Start(){
		particles = transform.Find("Particles").gameObject;
	}

	void Update(){
		StartCoroutine(Fire());
	}

	IEnumerator Fire(){
		if(Input.GetMouseButtonDown(1) && hasGun && !cooldown){
			cooldown = true;
			Vector3 ironSightsPos = transform.position;
			RaycastHit2D sight = Physics2D.Raycast(ironSightsPos, transform.up, 1);
			Debug.DrawRay(ironSightsPos, transform.up, Color.red);
			if(sight.transform.gameObject.tag == "Blockable"){
				cooldown = false;
				yield return null;
			}
			Managers.SoundManager.Instance.PlayColtSound();
			Managers.NPCManager.Instance.SendNoise(0f, 20f);
			Instantiate(objFire, ironSightsPos, new Quaternion(0, 0, 0, 0));
			yield return new WaitForSeconds(.4f);
			cooldown = false;
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
