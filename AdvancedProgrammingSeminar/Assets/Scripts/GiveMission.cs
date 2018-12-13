using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveMission : MonoBehaviour {

	GameObject player;
	GameObject cam;
	GameObject exclamation;
	public GameObject target;
	public Sprite question;
	public int id;
	public int completionBonus;
	bool viewed;
	[SerializeField]
	int moneyVal;
	bool isOpen = true;
	GuardScript targetGuard;
	JournalRender journal;
	CanvasGroup canvas;

	public bool targetDead;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		exclamation = transform.Find("Exclamation").gameObject;
		canvas = GameObject.Find("Canvas").GetComponent<CanvasGroup>();
		if(moneyVal > 0){
			exclamation.SetActive(false);
			isOpen = false;
		}
		targetGuard = target.GetComponent<GuardScript>();
	}

	void Update(){
		StartCoroutine(GetInput());
		if(moneyVal <= Managers.PlayerManager.Instance.totalCollectedCoins){
			isOpen = true;
			if(!Managers.QuestManager.Instance.questsCompleted[id]){
				exclamation.SetActive(true);
			}
		}
		if(targetGuard.dead){
			targetDead = true;
		}
		else {
			targetDead = false;
		}
	}

	IEnumerator GetInput(){
		if(Input.GetKeyDown(KeyCode.E) && !Managers.QuestManager.Instance.questsAccepted[id] && isOpen){
			if(Vector3.Distance(player.transform.position, this.transform.position) <= 3){
				viewed = true;
				if(!targetGuard.dead){
					ArrowLookAt();
					Managers.QuestManager.Instance.check.SetActive(true);
					Managers.QuestManager.Instance.x.SetActive(true);
					Managers.PlayerManager.Instance.cutscene = true;
					canvas.alpha = 0f;
					canvas.blocksRaycasts = false;
					GameObject view = target.transform.Find("View").gameObject;
					Vector3 camPos = cam.transform.position;
					cam.transform.position = new Vector3(view.transform.position.x, view.transform.position.y, -5);
					target.GetComponent<TargetScript>().text.SetActive(true);
					while(!Managers.QuestManager.Instance.checkPress && !Managers.QuestManager.Instance.xPress){
						yield return null;
					}
					if(Managers.QuestManager.Instance.checkPress){
						Managers.QuestManager.Instance.questsAccepted[id] = true;
						GetComponent<PolygonCollider2D>().isTrigger = true;
						exclamation.GetComponent<SpriteRenderer>().sprite = question;
					}
					Managers.QuestManager.Instance.checkPress = false;
					Managers.QuestManager.Instance.xPress = false;
					cam.transform.position = camPos;
					canvas.alpha = 1f;
					canvas.blocksRaycasts = true;
					target.GetComponent<TargetScript>().text.SetActive(false);
					Managers.QuestManager.Instance.check.SetActive(false);
					Managers.QuestManager.Instance.x.SetActive(false);
					Managers.PlayerManager.Instance.cutscene = false;
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.E) && viewed && !Managers.QuestManager.Instance.questsCompleted[id]){
			if(Vector3.Distance(player.transform.position, this.transform.position) <= 3){
				if(targetDead){
					Managers.PlayerManager.Instance.CoinCollected(completionBonus);
					Managers.QuestManager.Instance.questsCompleted[id] = true;
					exclamation.SetActive(false);
					Managers.PlayerManager.Instance.arrow.target = null;
					StartCoroutine(BlinkReward());
				}
				else if(Managers.QuestManager.Instance.questsAccepted[id] && viewed){
					StartCoroutine(Cutscene());
				}
			}
		}
	}

	public IEnumerator Cutscene(){
		ArrowLookAt();
		Managers.PlayerManager.Instance.cutscene = true;
		Managers.QuestManager.Instance.check.SetActive(true);
		canvas.alpha = 0f;
		canvas.blocksRaycasts = false;
		GameObject view = target.transform.Find("View").gameObject;
		Vector3 camPos = cam.transform.position;
		cam.transform.position = new Vector3(view.transform.position.x, view.transform.position.y, -5);
		target.GetComponent<TargetScript>().text.SetActive(true);
		while(!Managers.QuestManager.Instance.checkPress && !Input.GetKey(KeyCode.Escape)){
			yield return null;
		}
		Managers.QuestManager.Instance.checkPress = false;
		cam.transform.position = camPos;
		canvas.alpha = 1f;
		canvas.blocksRaycasts = true;
		target.GetComponent<TargetScript>().text.SetActive(false);
		Managers.QuestManager.Instance.check.SetActive(false);
		Managers.PlayerManager.Instance.cutscene = false;
	}

	void ArrowLookAt(){
		Managers.PlayerManager.Instance.arrow.target = target.transform;
	}

	IEnumerator BlinkReward(){
		Managers.NPCManager.Instance.getGold.SetActive(true);
		yield return new WaitForSeconds(2f);
		Managers.NPCManager.Instance.getGold.SetActive(false);
	}
}
