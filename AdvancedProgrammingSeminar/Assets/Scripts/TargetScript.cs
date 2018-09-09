using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

	public GameObject text;
	public int id;

	void Start(){
		text = transform.Find("Desc").gameObject;
		text.SetActive(false);
	}

}
