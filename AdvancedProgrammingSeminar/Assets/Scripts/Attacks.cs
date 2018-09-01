using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour {

	GameObject ironSights;
	public GameObject waterObj;
	GameObject curWeapon;
	GameObject[] wepList;
	int wepIndex = 0;

	void Start(){
		ironSights = transform.Find("IronSights").gameObject;
		curWeapon = waterObj;
		wepList = new GameObject[5];
		wepList[0] = waterObj;
		Managers.PlayerManager.Instance.weaponName = curWeapon.name;
	}

	void Update(){
		UpdateCurWep();
		Fire();
	}

	void Fire(){
		if(Input.GetMouseButtonDown(0)){
			Instantiate(curWeapon, ironSights.transform.position, ironSights.transform.rotation);
		}
	}

	void UpdateCurWep(){
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		if(scroll > 0){
			if(wepIndex + 1 <= 4){
				if(wepList[wepIndex + 1] != null){
					wepIndex++;
					curWeapon = wepList[wepIndex];
					Managers.PlayerManager.Instance.weaponName = curWeapon.name;
				}
			}
		}
		if(scroll < 0){
			if(wepIndex - 1 >= 0){
				if(wepList[wepIndex - 1] != null){
					wepIndex--;
					curWeapon = wepList[wepIndex];
					Managers.PlayerManager.Instance.weaponName = curWeapon.name;
				}
			}
		}
	}
}
