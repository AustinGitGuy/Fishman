using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers{
	public class NPCManager : Singleton<NPCManager> {

		public bool huntPlayer;
		public bool searchMode;
		public float timer;
		//Disguise variable here

		void Start(){
			
		}

		void Update(){
			if(huntPlayer){
				timer+=.016f;
				if(timer >= 20f){
					huntPlayer = false;
					timer = 0f;
					//Add the disguise check here
				}
			}
			if(searchMode){
				
			}
		}
	}
}