using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateView : MonoBehaviour {

	Button button;
	ViewQuest viewer;

	void Start(){
		button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
		viewer = GetComponentInParent<ViewQuest>();
	}

	void OnClick(){
		if(viewer.id != -1){
			StartCoroutine(Managers.QuestManager.Instance.clients[viewer.id].Cutscene());
		}
	}
}
