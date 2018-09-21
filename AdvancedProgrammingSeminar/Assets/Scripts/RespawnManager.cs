using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers {
	public class RespawnManager : Singleton<RespawnManager> {
		public Vector3 spawnPoint;
		GameObject player;
		public List<bool> questsAccepted;
		public List<bool> questsCompleted;
		public GameObject[] targets;
		public GameObject[] guards;

		void Start(){
			player = Managers.PlayerManager.Instance.GetPlayer();
			targets = GameObject.FindGameObjectsWithTag("Target");
			guards = GameObject.FindGameObjectsWithTag("Guard");
		}
		public void Respawn(){
			Managers.PlayerManager.Instance.health = 10f;
			player.transform.position = spawnPoint;
            Managers.NPCManager.Instance.huntPlayer = false;
            for(int i = 0; i < questsCompleted.Count; i++){
				for(int c = 0; c < targets.Length; c++){
					if(targets[c].GetComponent<TargetScript>().id == i){
						if(!questsCompleted[i]){
							targets[c].GetComponent<GuardScript>().dead = false;
                            targets[i].GetComponent<GuardScript>().alertMode = false;
                            targets[i].GetComponent<GuardScript>().noiseDetection = 0f;
                            targets[i].GetComponent<GuardScript>().crimeDetection = 0f;
                            targets[c].GetComponent<SpriteRenderer>().color = Color.white;
							targets[c].transform.position = targets[c].GetComponent<GuardScript>().spawnPos;
						}
					}
				}
			}
			for(int i = 0; i < guards.Length; i++){
				guards[i].GetComponent<GuardScript>().dead = false;
                guards[i].GetComponent<GuardScript>().alertMode = false;
                guards[i].GetComponent<GuardScript>().noiseDetection = 0f;
                guards[i].GetComponent<GuardScript>().crimeDetection = 0f;
                guards[i].GetComponent<SpriteRenderer>().color = Color.white;
				guards[i].transform.position = guards[i].GetComponent<GuardScript>().spawnPos;
			}
            Managers.NPCManager.Instance.huntPlayer = false;
        }
	}
}