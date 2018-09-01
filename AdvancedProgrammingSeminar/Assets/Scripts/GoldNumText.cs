using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldNumText : MonoBehaviour {

	void Update(){
		this.GetComponent<Text>().text = Managers.PlayerManager.Instance.totalCollectedCoins.ToString();
	}
}
