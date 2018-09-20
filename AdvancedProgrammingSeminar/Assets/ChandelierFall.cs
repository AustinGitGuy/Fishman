using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChandelierFall : MonoBehaviour {

    public Sprite destroyedSprite;
    public List<GameObject> casualties;
    bool initDestroy;

	void Start(){
		
	}
	
	void Update(){
        CheckDestroyed();
	}

    void CheckDestroyed(){
        if(GetComponent<WireScript>().output){
            initDestroy = true;
        }
        if(initDestroy){
            GetComponent<SpriteRenderer>().sprite = destroyedSprite;
            for(int i = 0; i < casualties.Count; i++){
                casualties[i].GetComponent<GuardScript>().DeathSequence();
            }
            initDestroy = false;
        }
    }
}
