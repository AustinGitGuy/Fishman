using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualNavPoint : MonoBehaviour {

	public Vector3 target;

	void Start(){
		target = new Vector3(transform.position.x, transform.position.y, 0);
	}

}
