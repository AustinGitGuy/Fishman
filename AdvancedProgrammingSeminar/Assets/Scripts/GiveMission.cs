using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveMission : MonoBehaviour {

	GameObject player;
	GameObject cam;
	GameObject canvas;
	GameObject exclamation;
	public GameObject target;
	public Sprite question;
	bool viewed;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		canvas = GameObject.Find("Canvas");
		exclamation = transform.Find("Exclamation").gameObject;
	}

	void Update(){
		StartCoroutine(GetInput());
	}

	IEnumerator GetInput(){
		if(Input.GetKeyDown(KeyCode.E) && !viewed){
			if(Vector3.Distance(player.transform.position, this.transform.position) <= 3){
				viewed = true;
				if(!target.GetComponent<GuardScript>().dead){
					Managers.PlayerManager.Instance.cutscene = true;
					canvas.SetActive(false);
					GameObject view = target.transform.Find("View").gameObject;
					Vector3 camPos = cam.transform.position;
					cam.transform.position = new Vector3(view.transform.position.x, view.transform.position.y, -5);
					target.GetComponent<TargetScript>().text.SetActive(true);
					yield return new WaitForSeconds(10f);
					cam.transform.position = camPos;
					canvas.SetActive(true);
					target.GetComponent<TargetScript>().text.SetActive(false);
					exclamation.GetComponent<SpriteRenderer>().sprite = question;
					Managers.PlayerManager.Instance.cutscene = false;
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.E) && viewed){
			if(Vector3.Distance(player.transform.position, this.transform.position) <= 5){
				if(target.GetComponent<GuardScript>().dead){
					Managers.PlayerManager.Instance.CoinCollected(1000);
					exclamation.SetActive(false);
				}
			}
		}
	}
}
