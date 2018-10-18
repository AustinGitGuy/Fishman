using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewQuest : MonoBehaviour {

	public int id;
	public string targetName;
	Text questText;
	Text viewText;

	void Start(){
		questText = GetComponent<Text>();
		viewText = transform.Find("View").GetComponent<Text>();
		id = -1;
	}
	
	void Update(){
		if(id == -1){
			questText.text = "";
			viewText.text = "";
		}
		else {
			viewText.text = "View Here";
			questText.text = targetName;
		}
	}
}
