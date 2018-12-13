using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

	[SerializeField]
	Transform follow;
	float yOffset;
	float xOffset;

    FadingText text;

	void Start(){
		xOffset = transform.position.x - follow.position.x;
		yOffset = transform.position.y - follow.position.y;
        text = GetComponent<FadingText>();
        if(text && (follow.tag == "Target" || follow.tag == "Guard")){
            text.setFade(true);
        }
	}
	
	void Update(){
		transform.position = new Vector3(follow.position.x + xOffset, follow.position.y + yOffset, transform.position.z);
	}
}
