using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchAtPlayer : MonoBehaviour {

	GameObject player;
	Rigidbody2D rb;
	float forceAmount = 750f;
	PlayThenDie sys;

	void Start(){
		sys = transform.Find("Splatter").GetComponent<PlayThenDie>();
		sys.gameObject.SetActive(false);
		rb = GetComponent<Rigidbody2D>();
		player = Managers.PlayerManager.Instance.GetPlayer();
		rb.AddForce((player.transform.position - transform.position).normalized * forceAmount);
		Destroy(this.gameObject, 10f);
	}

	void OnCollisionEnter2D(Collision2D col){
		transform.DetachChildren();
		sys.gameObject.SetActive(true);
		sys.Play();
		if(col.gameObject.tag == "Player"){
			Managers.PlayerManager.Instance.health-=1.25f;
			Destroy(this.gameObject);
		}
		else {
			Destroy(this.gameObject);
		}
	}
}
