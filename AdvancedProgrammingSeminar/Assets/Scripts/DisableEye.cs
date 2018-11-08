using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEye : MonoBehaviour {

	GameObject eye;
	ParticleSystem sys;
	bool deactivate;

	void Start(){
		eye = transform.Find("Eye").gameObject;
		eye.SetActive(false);
		sys = transform.Find("ParticleSystem").GetComponent<ParticleSystem>();
	}
	
	void Update(){
		if(Managers.NPCManager.Instance.seePlayer && !Managers.PlayerManager.Instance.cutscene){
			eye.SetActive(true);
			if(deactivate){
				sys.Play();
				deactivate = false;
			}
		}
		else {
			eye.SetActive(false);
			deactivate = true;
		}
	}
}
