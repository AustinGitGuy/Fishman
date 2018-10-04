using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigator : MonoBehaviour {
	//Navigation script copied and modified from Game Tech II class.
	public List<ManualNavPoint> patrolPoints;
	public enum MoveType {Walk, Run}
	public float walkSpeed = 5;
	public float runSpeed = 10;
	public bool isMoving = false;

	void Start(){
	}	
	void Update(){
		if(!isMoving && !GetComponent<GuardScript>().dead){
			StartCoroutine(MoveCharacter_Patrol(MoveType.Run, patrolPoints));
		}
	}

	public IEnumerator MoveCharacter_Patrol(MoveType movetype, List<ManualNavPoint> manualNavPoints){
		//Character will be moving
		isMoving = true;

		//Create list of positions from our ManualNavPoint targets
		List<Vector2> patrolDestinations = new List<Vector2>();
		
		foreach (ManualNavPoint point in manualNavPoints)
		{
			patrolDestinations.Add(point.target);
		}
		
		yield return StartCoroutine(CreateMoveOrder(movetype, patrolDestinations));
	}

	//Moving the character (When input is a single Waypoint)
	public IEnumerator MoveCharacter(MoveType moveType, Vector2 singleWaypoint)
	{
		//Character will be moving
		isMoving = true;

		//Create a list of points, then add the single point to it
		List<Vector2> waypoints = new List<Vector2>();
		waypoints.Add(singleWaypoint);

		//Move on to creating Move Order
		yield return StartCoroutine(CreateMoveOrder(moveType, waypoints));
	}

	//Moving the Character (When input is a series of waypoints)
	public IEnumerator MoveCharacter(MoveType moveType, List<Vector2> multipleWayPoints)
	{
		//Character will be moving
		isMoving = true;

		//Move on to creating Move Order
		yield return StartCoroutine(CreateMoveOrder(moveType, multipleWayPoints));
	}

	//////////////////////////////////////////////////////////////////////////////////////////

	private IEnumerator CreateMoveOrder(MoveType desiredMoveType, List<Vector2> destinationPoints){
		//For each Waypoint in the list
		for (int i = 0 ; i < destinationPoints.Count ; i++){
			//Send a move order to the waypoint, and wait for the character to reach a certain distance
			yield return StartCoroutine(MoveToNextWayPoint(destinationPoints[i]));
		}
		//Move order is complete - Set Moving to false
		isMoving = false;

		yield return null;
	}

	private IEnumerator MoveToNextWayPoint(Vector2 nextDesination){
		//Debug.Log(gameObject.name + " is moving towards" + nextDesination);
		//Set destination to current WayPoint
		Vector2 dir = nextDesination - (Vector2)transform.position;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		//Once the character has a valid path to the waypoint, and is not within a certain distance of the waypoint
		while(Vector2.Distance(transform.position, nextDesination) > .25){
			transform.position = Vector2.MoveTowards(transform.position, nextDesination, Time.deltaTime);
			yield return null;
		}
		//Debug.Log(gameObject.name + " has finished moving towards the point.");
	}

	private float DetermineMovementSpeed(MoveType desiredMoveType)
	{
		float newSpeed = 0;

		if(desiredMoveType == MoveType.Walk)
			newSpeed = walkSpeed;
		
		if(desiredMoveType == MoveType.Run)
			newSpeed = runSpeed;

		return newSpeed;
	}

	public void StopAllMovements(){
		this.StopAllCoroutines();
		isMoving = false;
	}
}
