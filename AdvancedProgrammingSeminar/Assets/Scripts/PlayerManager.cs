using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers{
	public class PlayerManager : Singleton<PlayerManager> {

		public int totalCollectedCoins = 0;
		public string weaponName;

		GameObject playerObject;

		void Start(){
			Cursor.visible = false;
			GetPlayer();
		}

		public void CoinCollected(int coinValue){
			totalCollectedCoins += coinValue;
		}

		public GameObject GetPlayer(){
			if(playerObject == null){
				playerObject = GameObject.Find("Player");
			}
			return playerObject;
		}
	}
}
