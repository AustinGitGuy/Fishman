using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

namespace Managers{
	public class PlayerManager : Singleton<PlayerManager> {

		public int totalCollectedCoins = 0;
		public string weaponName;
		public bool cutscene;

        public int redNum;
        public int greenNum;
        public int blueNum;

		public float health = 5;

		GameObject SMBlood;
		GameObject LGBlood;
		GameObject redCard;
		GameObject blueCard;
		GameObject greenCard;
		GameObject playerObject;
		public LookAt arrow;

        public PostProcessingProfile ppProfile;

		void Start(){
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
			if(health < 5){
				SMBlood.SetActive(true);
			}
			else {
				SMBlood.SetActive(false);
			}
			if(health < 3){
				LGBlood.SetActive(true);
			}
			else {
				LGBlood.SetActive(false);
			}
			if(health <= 0){
				Managers.RespawnManager.Instance.Respawn();
			}
            else{
                ChromaticAberrationModel.Settings chromSettings = ppProfile.chromaticAberration.settings;
                chromSettings.intensity = 5 / health - 1;
                ppProfile.chromaticAberration.settings = chromSettings;
            }
			health += .005f;
			if(health > 5){
				health = 5;
			}
            if(redNum > 0){
                redCard.SetActive(true);
            }
            else {
                redCard.SetActive(false);
            }
            if(blueNum > 0){
                blueCard.SetActive(true);
            }
            else {
                blueCard.SetActive(false);
            }
            if(greenNum > 0){
                greenCard.SetActive(true);
            }
            else {
                greenCard.SetActive(false);
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
