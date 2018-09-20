using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBullet : MonoBehaviour {

	Rigidbody2D rb;
	float forceAmount = 500f;
	GameObject player;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * forceAmount);
		Destroy(this.gameObject, 10f);
		player.GetComponent<FishScript>().crimeLevel -= 20f;
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Target" || col.gameObject.tag == "Client" || col.gameObject.tag == "Guard" || col.gameObject.tag == "Civilian"){
			Destroy(this.gameObject);
		} 
		else {
			Destroy(this.gameObject, 2f);
		}
	}
}
