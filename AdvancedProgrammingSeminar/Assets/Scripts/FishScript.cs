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
				noiseLevel = 0f;
			}
			rb.velocity = Vector2.zero;
		}
		else {
			if(carryingBody && !hiding){
				crimeLevel = .75f;
			}
			if(hiding){
				noiseLevel = 0f;
			}
			else {
				noiseLevel = .75f;
			}
		}
		float AngleRad = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, 
			Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x);
		float AngleDeg = (180 / Mathf.PI) * AngleRad;
		this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
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
