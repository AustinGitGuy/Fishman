using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {

    //Rigidbody2D rb;
    float xMove, yMove;
    float moveMod = .15f;

	void Start(){
        //rb = GetComponent<Rigidbody2D>();
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
        transform.position = new Vector2(transform.position.x + xMove * moveMod, transform.position.y + yMove * moveMod);
    }
}
