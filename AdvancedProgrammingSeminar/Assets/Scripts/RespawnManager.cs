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
            Managers.NPCManager.Instance.DisableHunt();
            for(int i = 0; i < questsCompleted.Count; i++){
				for(int c = 0; c < targets.Length; c++){
					if(targets[c].GetComponent<TargetScript>().id == i){
						if(!questsCompleted[i]){
							GuardScript gI = targets[c].GetComponent<GuardScript>();
                            gI.alertMode = false;
                            gI.noiseDetection = 0f;
                            gI.crimeDetection = 0f;
                            targets[c].GetComponent<SpriteRenderer>().color = Color.white;
							targets[c].transform.position = gI.spawnPos;
							//gI.dead = false;
							gI.health = gI.maxHealth;
						}
					}
				}
			}
			for(int i = 0; i < guards.Length; i++){
				GuardScript gI = guards[i].GetComponent<GuardScript>();
                gI.alertMode = false;
                gI.noiseDetection = 0f;
                gI.crimeDetection = 0f;
                guards[i].GetComponent<SpriteRenderer>().color = Color.white;
				guards[i].transform.position = gI.spawnPos;
				//gI.dead = false;
				gI.health = gI.maxHealth;
			}
            Managers.NPCManager.Instance.DisableHunt();
        }
	}
}