using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalRender : MonoBehaviour {

	public ViewQuest[] quests;
	[SerializeField]
	GiveMission[] clients;
	GameObject journal;
	public bool journalActive;

	void Start(){
		for(int i = 0; i < clients.Length; i++){
			clients[i] = GameObject.Find("Client" + i).GetComponent<GiveMission>();
		}
		journal = GameObject.Find("Journal");
		journal.SetActive(false);
	}
	
	void Update(){
		CheckInput();
	}

	public void GetEmptySlot(int id){
		for(int i = 0; i < quests.Length; i++){
			if(quests[i].id == id) return;
			if(quests[i].id == -1){
				quests[i].id = id;
				quests[i].targetName = clients[id].target.name;
				return;
			}
		}
	}

	void CheckInput(){
		if(Input.GetKeyDown(KeyCode.J)){
			journalActive = !journalActive;
			journal.SetActive(journalActive);
		}
	}

	void HideJournal(){
		
	}
}
