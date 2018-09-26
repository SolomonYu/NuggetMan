using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquireGuns : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "RocketPickup") {

			Combat combat = GetComponent<Combat> ();
			//index 1: rocket
			combat.weaponCounter[1] = 1;
			Debug.Log ("collected the Rocket");
			Destroy (coll.gameObject);

		}

		else if (coll.gameObject.tag == "MinigunPickup") {

			Combat combat = GetComponent<Combat> ();
			//index 2 is for flamethrower
			combat.weaponCounter[2] = 1;
			Debug.Log ("collected the minigun");
			Destroy(coll.gameObject);
		}
	}
}
