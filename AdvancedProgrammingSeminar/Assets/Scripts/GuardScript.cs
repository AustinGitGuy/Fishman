using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardScript : MonoBehaviour {

	public GameObject bullet;
	public Vector3 spawnPos;
	GameObject ironSights;
	GameObject player;
	bool playerRad;
	float sightLine = 20f;
	float decayRate = .2f;
	float detectionAmount = 7f;
	float detAngle = 40f;
	public float noiseDetection;
	public float crimeDetection;
	public bool alertMode;
	public bool dead;
	public bool seePlayer;
	bool firing;
	bool pickedUp;
	public bool citizen;
	int health = 2;

	void Start(){
		if(!citizen){
			ironSights = transform.Find("IronSights").gameObject;
		}
		player = Managers.PlayerManager.Instance.GetPlayer();
		spawnPos = this.transform.position;
	}

	void Update(){
		StartCoroutine(CheckDetection());
		HuntPlayer();
		CheckSight();
		CarryBody();
		StartCoroutine(FireAtPlayer());
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
			yield return null;
		}
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
		if(!seePlayer){
			alertMode = false;
		}
		if(crimeDetection >= detectionAmount && seePlayer){
			yield return new WaitForSeconds(.5f);
			if(!dead){
				alertMode = true;
				Managers.NPCManager.Instance.EnableHunt();
				Managers.NPCManager.Instance.timer = 0f;
			}
		}
		if(seePlayer && crimeDetection >= 1){
			yield return new WaitForSeconds(.5f);
			if(!dead){
				alertMode = true;
				Managers.NPCManager.Instance.EnableHunt();
				Managers.NPCManager.Instance.timer = 0f;
			}
		}
		if(Managers.NPCManager.Instance.getHunt()){
			if(noiseDetection >= detectionAmount){
				alertMode = true;
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
		Vector2 playerDir = player.transform.position - transform.position;
		float playerDist = Vector2.Distance(player.transform.position, transform.position);
		Vector3 dir = player.transform.position - transform.position;
		float angle = Vector2.Angle(dir, transform.position);
		if(playerDist <= sightLine && (Mathf.Abs((angle + transform.eulerAngles.z) - 180) <= detAngle)){
			RaycastHit2D[] sight = Physics2D.RaycastAll(transform.position, playerDir, playerDist);
			foreach(RaycastHit2D hit in sight){
				if(hit.transform.gameObject.tag == "Blockable" || hit.transform.gameObject.tag == "Hiding"){
					seePlayer = false;
					return;
				}
			}
			seePlayer = true;
			Debug.DrawRay(transform.position, playerDir, Color.red);
		}
		else {
			seePlayer = false;
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
		}
		//TODO: Move towards sound
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Noise"){
			playerRad = false;
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.tag == "Noise"){
			playerRad = true;
			noiseDetection += col.gameObject.GetComponentInParent<FishScript>().noiseLevel / (Vector2.Distance(this.gameObject.transform.position, 
				col.GetComponentInParent<Transform>().position) - 2);
			crimeDetection += col.gameObject.GetComponentInParent<FishScript>().crimeLevel / (Vector2.Distance(this.gameObject.transform.position, 
				col.GetComponentInParent<Transform>().position) / 4);
		}
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
		Debug.Log(gameObject.name + " died.");
		GetComponent<SpriteRenderer>().color = new Color(.6f, .6f, .6f);
		GetComponent<PolygonCollider2D>().isTrigger = true;
		dead = true;
		//TODO: Do something here
	}
}
