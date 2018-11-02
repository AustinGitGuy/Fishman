using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossGun : MonoBehaviour {

	Transform player;
	PlayerFire pGun;
	Transform myTransform;
	GameObject gun;

	void Start(){
		gun = transform.Find("Gun").gameObject;
		gun.SetActive(false);
		player = Managers.PlayerManager.Instance.GetPlayer().transform;
		pGun = player.GetComponent<PlayerFire>();
		myTransform = GetComponent<Transform>();
	}
	void Update(){
		if(Vector2.Distance(player.position, myTransform.position) <= 3){
			if(Input.GetKeyDown(KeyCode.E)){
				if(gun && pGun.hasGun){
					pGun.hasGun = false;
					gun.SetActive(true);
				}
			}
		}
	}
}
