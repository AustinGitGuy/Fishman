using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

	GameObject player;
	public Transform door;
    public Transform door2;
    public bool twoDoors;
	public bool vertical;
	public string color;
    bool doorOpen;

    FadingText text;

	void Start(){
        text = transform.Find("ReminderText").GetComponent<FadingText>();
        text.TurnOff();
		player = Managers.PlayerManager.Instance.GetPlayer();
	}
	
	void Update(){
		if(Vector2.Distance(player.transform.position, this.transform.position) <= 3){
            text.FadeIn();
			if(Input.GetKeyDown(KeyCode.E) && !doorOpen){
				if(color == "Red"){
					if(Managers.PlayerManager.Instance.redNum > 0){
                        if (vertical){
                            if(twoDoors){
                                door2.position = new Vector2(door2.position.x, door2.position.y + 2);
                            }
                            door.position = new Vector2(door.position.x, door.position.y + 2);
                        }
                        else {
                           if(twoDoors){
                                door2.position = new Vector2(door2.position.x + 2, door2.position.y);
                            }
                            door.position = new Vector2(door.position.x + 2, door.position.y);
                        }
                        Managers.PlayerManager.Instance.redNum--;
                        doorOpen = true;
					}
				}
				else if(color == "Blue"){
					if(Managers.PlayerManager.Instance.blueNum > 0){
                        if(vertical){
                            if(twoDoors){
                                door2.position = new Vector2(door2.position.x, door2.position.y + 2);
                            }
                            door.position = new Vector2(door.position.x, door.position.y + 2);                    
                        }
                        else {
                            if(twoDoors){
                                door2.position = new Vector2(door2.position.x + 2, door2.position.y);
                            }
                            door.position = new Vector2(door.position.x + 2, door.position.y);
                        }
						Managers.PlayerManager.Instance.blueNum--;
                        doorOpen = true;
					}
				}
				else if(color == "Green"){
					if(Managers.PlayerManager.Instance.greenNum > 0){
                        if(vertical){
                            if(twoDoors){
                                door2.position = new Vector2(door2.position.x, door2.position.y + 2);
                            }
                            door.position = new Vector2(door.position.x, door.position.y + 2);
                        }
                        else {
                            if(twoDoors){
                                door2.position = new Vector2(door2.position.x + 2, door2.position.y);
                            }
                            door.position = new Vector2(door.position.x + 2, door.position.y);
                        }
						Managers.PlayerManager.Instance.greenNum--;
                        doorOpen = true;
					}
				}
			}
		}
        else {
            text.FadeOut();
        }
	}
}
