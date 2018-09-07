using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchAtPlayer : MonoBehaviour {

	GameObject player;
	Rigidbody2D rb;
	float forceAmount = 250f;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		player = Managers.PlayerManager.Instance.GetPlayer();
		rb.AddForce((player.transform.position - transform.position).normalized * forceAmount);
		Destroy(this.gameObject, 10f);
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Guard" || col.gameObject.tag == "Target"){
			Destroy(this.gameObject, 1f);
		}
		else {
			Destroy(this.gameObject);
		}
	}
}
