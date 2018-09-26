using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanePos : MonoBehaviour {
	public int pos;
	//3 lanes: 1,2,3
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > -1.5f){
			pos = 1;
		}
		else if(transform.position.y > -3.6f){
			pos = 2;
		}
		else{
			pos = 3;
		}
		//print ("current position is: " + pos);
		
	}
}
