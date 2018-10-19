using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Managers {
	public class QuestManager : Singleton<QuestManager> {

		public List<bool> questsAccepted;
		public List<bool> questsCompleted;
		public GiveMission[] clients;
		public GameObject check;
		public GameObject x;
		public bool checkPress;
		public bool xPress;
		JournalRender journal;

		void Start(){
			clients = new GiveMission[questsCompleted.Count];
			for(int i = 0; i < questsCompleted.Count; i++){
				clients[i] = GameObject.Find("Client" + i).GetComponent<GiveMission>();
			}
			journal = GameObject.Find("Canvas").GetComponent<JournalRender>();
			Button btn1 = check.GetComponent<Button>();
			Button btn2 = x.GetComponent<Button>();
			btn1.onClick.AddListener(delegate {TaskWithParameters("Check"); });
			btn2.onClick.AddListener(delegate {TaskWithParameters("X"); });
			check.gameObject.SetActive(false);
			x.gameObject.SetActive(false);
		}

		void Update(){
			if(questsCompleted[5]){
				SceneManager.LoadScene("EndScene");
			}
			for(int i = 0; i < questsCompleted.Count; i++){
				if(questsAccepted[i]){
					if(!questsCompleted[i]){
						journal.GetEmptySlot(i);
					}
				}
			}
		}

		void TaskWithParameters(string type){
			if(type == "Check"){
				checkPress = true;
			}
			if(type == "X"){
				xPress = true;
			}
		}

	}
}