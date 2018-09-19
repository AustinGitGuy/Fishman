using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers{
	public class PlayerManager : Singleton<PlayerManager> {

		public int totalCollectedCoins = 0;
		public string weaponName;
		public bool cutscene;
		public bool redGot;
		public bool blueGot;
		public bool greenGot;
		public float health = 10;

		GameObject SMBlood;
		GameObject LGBlood;
		GameObject redCard;
		GameObject blueCard;
		GameObject greenCard;
		GameObject playerObject;

		void Start(){
			//Application.targetFrameRate = 60;
			GetPlayer();
			greenCard = GameObject.Find("GreenCard");
			redCard = GameObject.Find("RedCard");
			blueCard = GameObject.Find("BlueCard");
			SMBlood = GameObject.Find("SMBlood");
			LGBlood = GameObject.Find("LGBlood");
			redCard.SetActive(false);
			blueCard.SetActive(false);
			greenCard.SetActive(false);
			SMBlood.SetActive(false);
			LGBlood.SetActive(false);
		}

		void Update(){
			if(health < 10){
				SMBlood.SetActive(true);
			}
			else {
				SMBlood.SetActive(false);
			}
			if(health < 5){
				LGBlood.SetActive(true);
			}
			else {
				LGBlood.SetActive(false);
			}
			if(health <= 0){
				Managers.RespawnManager.Instance.Respawn();
			}
			health += .005f;
			if(health > 10){
				health = 10;
			}
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
