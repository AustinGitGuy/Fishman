using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour {

	Text weaponType;

	void Start(){
		weaponType = GetComponent<Text>();
	}

	void Update(){
		weaponType.text = Managers.PlayerManager.Instance.weaponName;
	}
}
