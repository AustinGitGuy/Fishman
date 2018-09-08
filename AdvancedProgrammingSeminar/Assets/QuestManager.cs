using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers {
	public class QuestManager : Singleton<QuestManager> {

		public List<bool> questsAccepted;
		public List<bool> questsCompleted;
		public GameObject check;
		public GameObject x;
		public bool checkPress;
		public bool xPress;

		void Start(){
			Button btn1 = check.GetComponent<Button>();
			Button btn2 = x.GetComponent<Button>();
			btn1.onClick.AddListener(delegate {TaskWithParameters("Check"); });
			btn2.onClick.AddListener(delegate {TaskWithParameters("X"); });
			check.gameObject.SetActive(false);
			x.gameObject.SetActive(false);
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