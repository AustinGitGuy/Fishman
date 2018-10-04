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
	public int id;
	public int completionBonus;
	bool viewed;
	[SerializeField]
	int moneyVal;
	bool isOpen = true;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		canvas = GameObject.Find("Canvas");
		exclamation = transform.Find("Exclamation").gameObject;
		if(moneyVal > 0){
			exclamation.SetActive(false);
			isOpen = false;	
		}
	}

	void Update(){
		StartCoroutine(GetInput());
		if(moneyVal <= Managers.PlayerManager.Instance.totalCollectedCoins){
			isOpen = true;
		}
	}

	IEnumerator GetInput(){
		if(Input.GetKeyDown(KeyCode.E) && !Managers.QuestManager.Instance.questsAccepted[id] && isOpen){
			if(Vector3.Distance(player.transform.position, this.transform.position) <= 3){
				viewed = true;
				if(!target.GetComponent<GuardScript>().dead){
					Managers.QuestManager.Instance.check.SetActive(true);
					Managers.QuestManager.Instance.x.SetActive(true);
					Managers.PlayerManager.Instance.cutscene = true;
					canvas.SetActive(false);
					GameObject view = target.transform.Find("View").gameObject;
					Vector3 camPos = cam.transform.position;
					cam.transform.position = new Vector3(view.transform.position.x, view.transform.position.y, -5);
					target.GetComponent<TargetScript>().text.SetActive(true);
					while(!Managers.QuestManager.Instance.checkPress && !Managers.QuestManager.Instance.xPress){
						yield return null;
					}
					if(Managers.QuestManager.Instance.checkPress){
						Managers.QuestManager.Instance.questsAccepted[id] = true;
						exclamation.GetComponent<SpriteRenderer>().sprite = question;
					}
					Managers.QuestManager.Instance.checkPress = false;
					Managers.QuestManager.Instance.xPress = false;
					cam.transform.position = camPos;
					canvas.SetActive(true);
					target.GetComponent<TargetScript>().text.SetActive(false);
					Managers.QuestManager.Instance.check.SetActive(false);
					Managers.QuestManager.Instance.x.SetActive(false);
					Managers.PlayerManager.Instance.cutscene = false;
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.E) && viewed){
			if(Vector3.Distance(player.transform.position, this.transform.position) <= 3){
				if(target.GetComponent<GuardScript>().dead){
					Managers.PlayerManager.Instance.CoinCollected(completionBonus);
					Managers.QuestManager.Instance.questsCompleted[id] = true;
					exclamation.SetActive(false);
				}
			}
		}
	}
}
