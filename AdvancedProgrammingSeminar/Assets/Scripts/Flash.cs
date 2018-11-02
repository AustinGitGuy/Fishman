using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {

	SpriteRenderer sprite;

	void Start(){
		sprite = GetComponent<SpriteRenderer>();
		InvokeRepeating("FlashObj", Time.deltaTime, .5f);
	}

	void FlashObj(){
		sprite.enabled = !sprite.enabled;
	}
}
