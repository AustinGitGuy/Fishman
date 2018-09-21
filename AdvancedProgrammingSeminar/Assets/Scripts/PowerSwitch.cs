using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSwitch : MonoBehaviour {

    public GameObject attachTo;
    GameObject player;
    public int lineNum;
    public bool switchable;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
	}
	
	void Update(){
        GetInput();
	}

    void GetInput(){
        if(Input.GetKeyDown(KeyCode.E) && Vector3.Distance(player.transform.position, this.transform.position) <= 3){
            if(switchable){
                if(lineNum == 0){
                    attachTo.GetComponent<WireScript>().line1 = !attachTo.GetComponent<WireScript>().line1;
                }
                if(lineNum == 1){
                    attachTo.GetComponent<WireScript>().line2 = !attachTo.GetComponent<WireScript>().line2;
                }
            }
            if(lineNum == 0){
                attachTo.GetComponent<WireScript>().line1 = true;
            }
            if(lineNum == 1){
                attachTo.GetComponent<WireScript>().line2 = true;
            }
        }
    }
}
