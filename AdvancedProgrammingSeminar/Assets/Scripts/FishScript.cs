using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {

	//Noise level is used for everyday things (walking), crime level is used for things that are crimes (shooting, attacking, stealing, tripping alarms)
	public float noiseLevel;
	public float crimeLevel;
    Rigidbody2D rb;
    float xMove, yMove;
    float moveMod = 5f;
	bool hiding;
	public bool carryingBody;

	void Start(){
        rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
        GetInput();
        Move();
	}

    void GetInput(){
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");
    }

    void Move(){
		rb.velocity = new Vector2(xMove * moveMod, yMove * moveMod);
		if(xMove == 0 && yMove == 0){
			if(hiding){
				noiseLevel = -.75f;
			}
			else {
				noiseLevel = -.5f;
			}
			rb.velocity = Vector2.zero;
			rb.angularVelocity = 0f;
		}
		else {
			if(hiding){
				noiseLevel = 0f;
			}
			else {
				noiseLevel = .75f;
			}
		}
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 90f);
		if(transform.eulerAngles.z > 90f && transform.eulerAngles.z < 270f){
			transform.eulerAngles = new Vector3(0, 180, -transform.eulerAngles.z + 180f);
		}
    }

	void OnTriggerStay2D(Collider2D col){
		if(col.tag == "Hiding"){
			hiding = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Hiding"){
			hiding = false;
		}
	}
}
