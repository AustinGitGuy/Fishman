using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceSkin : MonoBehaviour {

	GameObject player;
	SpriteRenderer playerRenderer;
	SpriteRenderer thisRenderer;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
		playerRenderer = player.GetComponent<SpriteRenderer>();
		thisRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update(){
		if(Input.GetKeyDown(KeyCode.E)){
			if(Vector2.Distance(player.transform.position, this.transform.position) <= 3){
				Sprite pSprite = playerRenderer.sprite;
				playerRenderer.sprite = thisRenderer.sprite;
				thisRenderer.sprite = pSprite;
			}
		}
	}
}
