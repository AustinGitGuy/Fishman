using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBullet : MonoBehaviour {

	Rigidbody2D rb;
	float forceAmount = 750f;
	GameObject player;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
		rb = GetComponent<Rigidbody2D>();
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);
		transform.rotation = rot;
		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
		rb.AddForce(transform.up * forceAmount);
		Destroy(this.gameObject, 10f);
        StartCoroutine(FallBack());
	}

    IEnumerator FallBack(){
        yield return new WaitForSeconds(1f);
        player.GetComponent<FishScript>().crimeLevel -= 20f;
    }

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Target" || col.gameObject.tag == "Client" || col.gameObject.tag == "Guard" || col.gameObject.tag == "Civilian"){
            player.GetComponent<FishScript>().crimeLevel -= 20f;
            Destroy(this.gameObject);
		} 
		else {
			Destroy(this.gameObject, 2f);
		}
	}
}
