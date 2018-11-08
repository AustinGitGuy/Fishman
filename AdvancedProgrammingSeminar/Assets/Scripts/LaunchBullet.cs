using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBullet : MonoBehaviour {

	Rigidbody2D rb;
	float forceAmount = 750f;
	PlayThenDie sys;

	void Start(){
		sys = transform.Find("Splatter").GetComponent<PlayThenDie>();
		sys.gameObject.SetActive(false);
		rb = GetComponent<Rigidbody2D>();
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
		rb.AddForce(transform.up * forceAmount);
	}

	void OnCollisionEnter2D(Collision2D col){
		transform.DetachChildren();
		sys.gameObject.SetActive(true);
		sys.Play();
		Destroy(this.gameObject);
	}
}
