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
		public bool seePlayer;
		GuardScript[] people;
		public GameObject getGold;

		void Start(){
			getGold = GameObject.Find("GetGold");
			getGold.SetActive(false);
			people = (GuardScript[]) GameObject.FindObjectsOfType(typeof(GuardScript));
			alerted = GameObject.Find("AlertedText").GetComponent<Text>();
			alerted.gameObject.SetActive(false);
		}

		void Update(){
			if(huntPlayer){
				timer+=.016f;
				if(timer >= 10f){
					DisableHunt();
				}
			}
			if(searchMode){
				
			}
			for(int i = 0; i < people.Length; i++){
				if(people[i].seePlayer){
					seePlayer = true;
					break;
				}
				seePlayer = false;
			}
		}

		public void SendNoise(float noiseLevel, float crimeLevel){
			for(int i = 0; i < people.Length; i++){
				people[i].AddNoise(noiseLevel, crimeLevel);
			}
		}
		
		public void DisableHunt(){
			huntPlayer = false;
			alerted.gameObject.SetActive(false);
			timer = 0f;
		}

		public void EnableHunt(){
			huntPlayer = true;
			alerted.gameObject.SetActive(true);
		}

		public bool getHunt(){
			return huntPlayer;
		}
	}
}