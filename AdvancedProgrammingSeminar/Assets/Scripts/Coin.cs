using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public int goldValue = 1;

	void OnTriggerEnter(Collider col){
		//When it collides with the player, add the gold value then delete it
		if(col.gameObject.tag == "Player"){
			Managers.PlayerManager.Instance.CoinCollected(goldValue);
			Destroy(this.gameObject);
		}
	}
}
