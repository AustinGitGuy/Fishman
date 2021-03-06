﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardScript : MonoBehaviour {

	//Death sound is copyright Roblox

	public GameObject bullet;
	public Vector3 spawnPos;
	GameObject ironSights;
	GameObject player;
	float sightLine = 7f;
	float decayRate = .2f;
	float crimeDetectionAmount = 1f;
	float noiseDetectionAmount = 7f;
	float detAngle = 50f;
	public float noiseDetection;
	public float crimeDetection;
	public bool alertMode;
	public bool dead;
	public bool seePlayer;
	bool hearPlayer;
	bool firing;
	bool pickedUp;
	public bool citizen;
	public int health = 1;
	public int maxHealth = 1;
	[SerializeField]
	bool shootOnSight;

	public float angle;
	void Start(){
		if(!citizen){
			ironSights = transform.Find("IronSights").gameObject;
		}
		health = maxHealth;
		player = Managers.PlayerManager.Instance.GetPlayer();
		spawnPos = this.transform.position;
	}

	void Update(){
		if(!dead){
			StartCoroutine(CheckDetection());
			HuntPlayer();
			CheckSight();
			CheckHearing();
			StartCoroutine(FireAtPlayer());
		}
		if(dead){
			seePlayer = false;
		}
		CarryBody();
	}

	void CarryBody(){
		if(dead){
			if(Vector2.Distance(this.transform.position, player.transform.position) <= 2 && !player.GetComponent<FishScript>().carryingBody && !pickedUp){
				if(Input.GetKeyDown(KeyCode.Q)){
					pickedUp = true;
					transform.SetParent(player.transform);
					player.GetComponent<FishScript>().carryingBody = true;
				}
			}
			else {
				if(Input.GetKeyDown(KeyCode.Q) && player.GetComponent<FishScript>().carryingBody && pickedUp){
					pickedUp = false;
					transform.SetParent(null);
					player.GetComponent<FishScript>().carryingBody = false;
				}
			}
		}
	}

	IEnumerator CheckDetection(){
		if(dead || citizen){
			seePlayer = false;
			yield return null;
		}
		noiseDetection -= decayRate;
		crimeDetection -= decayRate;
		if(noiseDetection >= 20){
			noiseDetection = 20;
		}
		if(noiseDetection <= 0){
			noiseDetection = 0;
		}
		if(crimeDetection >= 20){
			crimeDetection = 20;
		}
		if(crimeDetection <= 0){
			crimeDetection = 0;
		}
		if(!seePlayer){
			alertMode = false;
		}
		if(seePlayer || hearPlayer){
			Vector3 dir = player.transform.position - transform.position;
			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			if(transform.eulerAngles.z > 90f && transform.eulerAngles.z < 270f){
				transform.eulerAngles = new Vector3(0, 180, -transform.eulerAngles.z + 180f);
			}
		}
		if(crimeDetection >= crimeDetectionAmount && seePlayer){
			yield return new WaitForSeconds(.5f);
			if(!dead){
				alertMode = true;
				Managers.NPCManager.Instance.EnableHunt();
				Managers.NPCManager.Instance.timer = 0f;
			}
		}
		if(seePlayer && Managers.NPCManager.Instance.getHunt()){
			alertMode = true;
			Managers.NPCManager.Instance.timer = 0f;
		}
		if(seePlayer && player.GetComponent<FishScript>().carryingBody){
			yield return new WaitForSeconds(.5f);
			if(!dead){
				alertMode = true;
				Managers.NPCManager.Instance.EnableHunt();
				Managers.NPCManager.Instance.timer = 0f;
			}
		}
		if(alertMode && !Managers.NPCManager.Instance.getHunt()){
			alertMode = false;
		}
		if(seePlayer && shootOnSight){
			alertMode = true;
		}
	}

	IEnumerator FireAtPlayer(){
		if(seePlayer && !firing && alertMode && !dead && !citizen){
			firing = true;
			Instantiate(bullet, ironSights.transform.position, ironSights.transform.rotation);
			yield return new WaitForSeconds(.5f);
			firing = false;
		}
	}

	void CheckSight(){
		Vector3 dir = player.transform.position - transform.position;
		float playerDist = Vector2.Distance(player.transform.position, transform.position);
		angle = Vector3.Angle(transform.right, dir);
		if(playerDist <= sightLine && angle <= detAngle){
			RaycastHit2D[] sight = Physics2D.RaycastAll(transform.position, dir, playerDist);
			foreach(RaycastHit2D hit in sight){
				if(hit.transform.gameObject.tag == "Blockable" || hit.transform.gameObject.tag == "Hiding"){
					seePlayer = false;
					return;
				}
			}
			if(!dead){
				seePlayer = true;
				Debug.DrawRay(transform.position, dir, Color.red);
			}
		}
		else {
			seePlayer = false;
		}
	}

	void CheckHearing(){
		if(noiseDetection <= noiseDetectionAmount && crimeDetection <= crimeDetectionAmount){
			return;
		}
		Vector3 dir = player.transform.position - transform.position;
		float playerDist = Vector2.Distance(player.transform.position, transform.position);
		if(playerDist <= sightLine){
			RaycastHit2D[] sight = Physics2D.RaycastAll(transform.position, dir, playerDist);
			foreach(RaycastHit2D hit in sight){
				if(hit.transform.gameObject.tag == "Blockable" || hit.transform.gameObject.tag == "Hiding"){
					seePlayer = false;
					return;
				}
			}
			if(!dead){
				hearPlayer = true;
				Debug.DrawRay(transform.position, dir, Color.red);
			}
		}
		else {
			hearPlayer = false;
		}
	}

	void HuntPlayer(){
		if(dead || citizen){
			return;
		}
		if(alertMode && seePlayer){
			transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
			Vector3 dir = player.transform.position - transform.position;
			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			if(transform.eulerAngles.z > 90f && transform.eulerAngles.z < 270f){
				transform.eulerAngles = new Vector3(0, 180, -transform.eulerAngles.z + 180f);
			}
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.tag == "Target" || col.tag == "Guard"){
			if(col.GetComponent<GuardScript>().dead){
				Vector2 targetDir = col.transform.position - transform.position;
				float targetDist = Vector2.Distance(col.transform.position, transform.position);
				Vector3 dir = col.transform.position - transform.position;
				float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
				if(targetDist <= sightLine && (angle <= detAngle && angle >= -detAngle)){
					RaycastHit2D[] sight = Physics2D.RaycastAll(transform.position, targetDir, targetDist);
					Debug.DrawRay(transform.position, targetDir, Color.red);
					foreach(RaycastHit2D hit in sight){
						if(hit.transform.gameObject.tag == "Blockable" || hit.transform.gameObject.tag == "Hiding"){
							return;
						}
					}
					Managers.NPCManager.Instance.searchMode = true;
				}
			}
		}
	}

	public void AddNoise(float noiseLevel, float crimeLevel){
		float dist = Vector2.Distance(player.transform.position, transform.position);
		noiseDetection += noiseLevel / dist;
		crimeDetection += crimeLevel / dist;
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Projectile"){
			if(!dead){
				health--;
			}
			if(health <= 0 && !dead){
				DeathSequence();
			}
		}
	}

	public void DeathSequence(){
        if(GetComponent<Navigator>() != null){
            GetComponent<Navigator>().StopAllMovements();
        }
		Managers.SoundManager.Instance.PlayDeathSound();
		Debug.Log(gameObject.name + " died.");
		GetComponent<SpriteRenderer>().color = new Color(.2f, .2f, .2f);
		GetComponent<PolygonCollider2D>().isTrigger = true;
		dead = true;
	}
}
