using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour {

	GameObject journal;

	bool journalActive;

	void Start(){
		journal = GameObject.Find("Journal");
		journal.SetActive(false);
	}

	void Update(){
		CheckInput();
	}

	void CheckInput(){
		if(Input.GetKeyDown(KeyCode.J)){
			journalActive = !journalActive;
			journal.SetActive(journalActive);
		}
	}
}
