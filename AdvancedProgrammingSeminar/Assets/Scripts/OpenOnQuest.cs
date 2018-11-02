using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOnQuest : MonoBehaviour {

	[SerializeField]
	bool vertical;
	[SerializeField]
	int questNum;
	bool open;

	void Start(){
		
	}
	
	void Update(){
		if(!open && Managers.QuestManager.Instance.questsAccepted[questNum]){
			OpenDoor();
		}
	}

	void OpenDoor(){
		open = true;
		if(vertical){
            transform.position = new Vector2(transform.position.x, transform.position.y + 2);
		}
        else {
            transform.position = new Vector2(transform.position.x + 2, transform.position.y);
        }
	}
}
