using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

	[SerializeField]
	Transform follow;
	float yOffset;
	float xOffset;

	void Start(){
		xOffset = transform.position.x - follow.position.x;
		yOffset = transform.position.y - follow.position.y;
	}
	
	void Update(){
		transform.position = new Vector3(follow.position.x + xOffset, follow.position.y + yOffset, transform.position.z);
	}
}
