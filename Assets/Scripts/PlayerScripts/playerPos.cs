using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPos : MonoBehaviour {
	public int pos;
	bool isJumping;
	float groundHeight;
	//3 lanes: 1,2,3
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		isJumping = gameObject.GetComponent<Movement> ().isJumping;
		groundHeight = gameObject.GetComponent<Movement> ().groundHeight;

		if (!isJumping) {
			if (transform.position.y > -1.5f) {
				pos = 1;
			} else if (transform.position.y > -3.6f) {
				pos = 2;
			} else {
				pos = 3;
			}
		}
		else{
			if (groundHeight > -1.5f) {
				pos = 1;
			} else if (groundHeight > -3.6f) {
				pos = 2;
			} else {
				pos = 3;
			}
		}
			
		//print ("current position is: " + pos);

	}
}
