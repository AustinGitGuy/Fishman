using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {

    Rigidbody2D rb;
    float yMove;
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
        yMove = Input.GetAxis("Vertical");
    }

    void Move(){
		GenerateNoise();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 90f);
		if(transform.eulerAngles.z > 90f && transform.eulerAngles.z < 270f){
			transform.eulerAngles = new Vector3(0, 180, -transform.eulerAngles.z + 180f);
		}
		if(yMove == 0){
			rb.velocity = Vector2.zero;
			rb.angularVelocity = 0f;
		}
		else {
			rb.velocity = transform.right * moveMod;
		}
    }

	void GenerateNoise(){
		if(hiding){
			Managers.NPCManager.Instance.SendNoise(-.5f, -.5f);
		}
		else if(yMove != 0){
			Managers.NPCManager.Instance.SendNoise(.75f, 0f);
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
