using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

	void OnTriggerStay2D(Collider2D col){
		if(!Managers.NPCManager.Instance.huntPlayer){
			Managers.RespawnManager.Instance.spawnPoint = this.transform.position;
			Managers.RespawnManager.Instance.questsAccepted = Managers.QuestManager.Instance.questsAccepted;
			Managers.RespawnManager.Instance.questsCompleted = Managers.QuestManager.Instance.questsCompleted;
		}
	}
}
