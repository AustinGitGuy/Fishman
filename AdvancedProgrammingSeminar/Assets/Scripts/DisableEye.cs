using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEye : MonoBehaviour {

	GameObject eye;

	void Start(){
		eye = transform.Find("Eye").gameObject;
		eye.SetActive(false);
	}
	
	void Update(){
		if(Managers.NPCManager.Instance.seePlayer){
			eye.SetActive(true);
		}
		else {
			eye.SetActive(false);
		}
	}
}
