using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers{
	public class NPCManager : Singleton<NPCManager> {

		public bool huntPlayer;
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
				alerted.gameObject.SetActive(true);
				timer+=.016f;
				if(timer >= 20f){
					huntPlayer = false;
					alerted.gameObject.SetActive(false);
					timer = 0f;
					//Add the disguise check here
				}
			}
			if(searchMode){
				
			}
		}
	}
}