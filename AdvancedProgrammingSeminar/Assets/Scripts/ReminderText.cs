using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReminderText : MonoBehaviour {

    [SerializeField]
    FadingText text;
    GameObject player;

	void Start(){
        player = Managers.PlayerManager.Instance.GetPlayer();
        if(!text){
            text = transform.Find("ReminderText").GetComponent<FadingText>();
        }
        text.TurnOff();
    }

    void Update(){
        if(Vector2.Distance(player.transform.position, this.transform.position) <= 3){
            text.FadeIn();
        }
        else {
            text.FadeOut();
        }
    }
}
