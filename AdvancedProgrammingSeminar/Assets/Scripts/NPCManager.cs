using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers{
	public class NPCManager : Singleton<NPCManager> {

		bool huntPlayer;
		public bool searchMode;
		public float timer;
		Text alerted;
		//Disguise variable here

		void Start(){
			alerted = GameObject.Find("AlertedText").GetComponent<Text>();
			alerted.gameObject.SetActive(false);
		}

		void Update(){
			if(huntPlayer){
				timer+=.016f;
				if(timer >= 20f){
					DisableHunt();
				}
			}
			if(searchMode){
				
			}
		}
		
		public void DisableHunt(){
			Debug.Log("Disabling Hunt");
			huntPlayer = false;
			alerted.gameObject.SetActive(false);
			timer = 0f;
		}

		public void EnableHunt(){
			huntPlayer = true;
			Debug.Log("Hunting Player");
			alerted.gameObject.SetActive(true);
		}

		public bool getHunt(){
			return huntPlayer;
		}
	}
}