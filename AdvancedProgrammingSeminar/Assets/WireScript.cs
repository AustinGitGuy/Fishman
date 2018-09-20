using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScript : MonoBehaviour {

    public bool line1;
    public bool line2;
    public bool output;
    public enum WireType {And, Or, Single};
    public WireType type;
	
	void Update(){
        if(type == WireType.And){
            if(line1 && line2){
                output = true;
            }
            else {
                output = false;
            }
        }
        if(type == WireType.Or){
            if(line1 || line2){
                output = true;
            }
            else {
                output = false;
            }
        }
        if(type == WireType.Single){
            output = line1;
        }
    }
}
