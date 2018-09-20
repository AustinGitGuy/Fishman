using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

	GameObject player;
	public GameObject door;
    public GameObject door2;
    public bool twoDoors;
	public bool vertical;
	public string color;

	void Start(){
		player = Managers.PlayerManager.Instance.GetPlayer();
	}
	
	void Update(){
		if(Vector2.Distance(player.transform.position, this.transform.position) <= 3){
			if(Input.GetKeyDown(KeyCode.E)){
				if(color == "Red"){
					if(Managers.PlayerManager.Instance.redNum > 0){
                        if (vertical){
                            if(twoDoors){
                                door2.transform.position = new Vector2(door2.transform.position.x, door2.transform.position.y + 2);
                            }
                            door.transform.position = new Vector2(door.transform.position.x, door.transform.position.y + 2);
                        }
                        if(twoDoors){
                            door2.transform.position = new Vector2(door2.transform.position.x + 2, door2.transform.position.y);
                        }
						door.transform.position = new Vector2(door.transform.position.x + 2, door.transform.position.y);
                        Managers.PlayerManager.Instance.redNum--;
					}
				}
				if(color == "Blue"){
					if(Managers.PlayerManager.Instance.blueNum > 0){
                        if(vertical){
                            if(twoDoors){
                                door2.transform.position = new Vector2(door2.transform.position.x, door2.transform.position.y + 2);
                            }
                            door.transform.position = new Vector2(door.transform.position.x, door.transform.position.y + 2);
                        }
                        else {
                            if(twoDoors){
                                door2.transform.position = new Vector2(door2.transform.position.x + 2, door2.transform.position.y);
                            }
                            door.transform.position = new Vector2(door.transform.position.x + 2, door.transform.position.y);
                        }
						Managers.PlayerManager.Instance.blueNum--;
					}
				}
				if(color == "Green"){
					if(Managers.PlayerManager.Instance.greenNum > 0){
                        if(vertical){
                            if(twoDoors){
                                door2.transform.position = new Vector2(door2.transform.position.x, door2.transform.position.y + 2);
                            }
                            door.transform.position = new Vector2(door.transform.position.x, door.transform.position.y + 2);
                        }
                        if(twoDoors){
                            door2.transform.position = new Vector2(door2.transform.position.x + 2, door2.transform.position.y);
                        }
                        door.transform.position = new Vector2(door.transform.position.x + 2, door.transform.position.y);
						Managers.PlayerManager.Instance.greenNum--;
					}
				}
			}
		}
	}
}
