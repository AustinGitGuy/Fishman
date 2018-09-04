using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardScript : MonoBehaviour {

	public GameObject bullet;
	GameObject ironSights	;
	GameObject player;
	bool playerRad;
	float sightLine = 20f;
	float decayRate = .2f;
	float detectionAmount = 7f;
	float upperAngle = 6f;
	float lowerAngle = -16f;
	public float noiseDetection;
	public float crimeDetection;
	bool alertMode;
	Rigidbody2D rb;
	public bool dead;
	public bool seePlayer;
	bool firing;

	void Start(){
		ironSights = transform.Find("IronSights").gameObject;
		rb = GetComponent<Rigidbody2D>();
		player = Managers.PlayerManager.Instance.GetPlayer();
	}

	void Update(){
		CheckDetection();
		HuntPlayer();
		CheckSight();
		CarryBody();
		StartCoroutine(FireAtPlayer());
	}

	void CarryBody(){
		if(dead){
			if(Vector2.Distance(this.transform.position, player.transform.position) <= 1){
				if(Input.GetKeyDown(KeyCode.Q)){
					transform.SetParent(player.transform);
					player.GetComponent<FishScript>().carryingBody = true;
					rb.simulated = false;
				}
			}
			else {
				if(Input.GetKeyDown(KeyCode.Q) && player.GetComponent<FishScript>().carryingBody){
					transform.SetParent(null);
					player.GetComponent<FishScript>().carryingBody = false;
					rb.simulated = true;
				}
			}
		}
	}

	void CheckDetection(){
		if(!playerRad){
			noiseDetection -= decayRate;
			crimeDetection -= decayRate;
		}
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
		if(crimeDetection >= detectionAmount && !dead){
			alertMode = true;
			Managers.NPCManager.Instance.huntPlayer = true;
			Managers.NPCManager.Instance.timer = 0f;
		}
		if(Managers.NPCManager.Instance.huntPlayer && !dead){
			if(noiseDetection >= detectionAmount){
				alertMode = true;
				Managers.NPCManager.Instance.timer = 0f;
			}
		}
		if(seePlayer && !dead && Managers.NPCManager.Instance.huntPlayer){
			alertMode = true;
		}
		if(!dead && alertMode && !Managers.NPCManager.Instance.huntPlayer){
			alertMode = false;
		}
	}

	IEnumerator FireAtPlayer(){
		if(seePlayer && !firing && alertMode){
			firing = true;
			Instantiate(bullet, ironSights.transform.position, ironSights.transform.rotation);
			yield return new WaitForSeconds(.5f);
			firing = false;
		}
	}

	void CheckSight(){
		Vector2 playerDir = player.transform.position - transform.position;
		float playerDist = Vector2.Distance(player.transform.position, transform.position);
		if(playerDist <= sightLine && (Vector2.SignedAngle(transform.position, player.transform.position) <= upperAngle && 
			Vector2.SignedAngle(transform.position, player.transform.position) >= lowerAngle)){
			RaycastHit2D[] sight = Physics2D.RaycastAll(transform.position, playerDir, playerDist);
			Debug.DrawRay(transform.position, playerDir, Color.red);
			foreach(RaycastHit2D hit in sight){
				if(hit.transform.gameObject.tag == "Blockable" || hit.transform.gameObject.tag == "Hiding"){
					seePlayer = false;
					return;
				}
			}
			seePlayer = true;
		}
		else {
			seePlayer = false;
		}
	}

	void HuntPlayer(){
		if(alertMode && !dead){
			transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
			Vector3 dir = player.transform.position - transform.position;
			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Noise"){
			playerRad = false;
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.tag == "Noise"){
			playerRad = true;
			noiseDetection += col.gameObject.GetComponentInParent<FishScript>().noiseLevel / Vector2.Distance(this.gameObject.transform.position, 
				col.GetComponentInParent<Transform>().position);
			crimeDetection += col.gameObject.GetComponentInParent<FishScript>().crimeLevel / Vector2.Distance(this.gameObject.transform.position, 
				col.GetComponentInParent<Transform>().position);
		}
		if(col.tag == "Target" || col.tag == "Guard"){
			if(col.GetComponent<GuardScript>().dead){
				Vector2 targetDir = col.transform.position - transform.position;
				float targetDist = Vector2.Distance(col.transform.position, transform.position);
				if(targetDist <= sightLine && (Vector2.SignedAngle(transform.position, col.transform.position) <= upperAngle && 
					Vector2.SignedAngle(transform.position, col.transform.position) >= lowerAngle)){
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

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Projectile"){
			if(!dead){
				DeathSequence();
			}
		}
	}

	void DeathSequence(){
		dead = true;
		//TODO: Do something here
	}
}
