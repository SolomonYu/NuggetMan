using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {
	bool isForward;
	float pistolCooldown;
	float minigunCooldown;
	float rocketCooldown;

	float minigunSpool;
	bool miniIsFire;
	public float minigunOverheat;

	public int weaponIndex = 0;
		//0 = grease gun
		//1 = sword
		//2 = minigun

	public GameObject[] weaponObjects;

	public int[] weaponCounter; //.= {1, 0, 0}; //tracks which weapons the player possesses

	int i = 0;	//tracks weapon switching - start at grease gun

	public GameObject psound;
	public GameObject rsound;
	public GameObject msound;
	public GameObject chargesound;
	public GameObject reloadsound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		isForward = gameObject.GetComponent<Movement> ().isForward;

		if (Input.GetKey (KeyCode.K)) {

			//grease gun - 0
			if (weaponIndex == 0) {
				fire_greasegun ();
			}
			//sword - 1
			if (weaponIndex == 1) {
				fire_rocket ();
			}
			//minigun - 2
			if (weaponIndex == 2) {
				fire_minigun ();
			}
		} else {
			if (minigunOverheat > 0) {
				minigunOverheat -= 1;
			}
		}
		if (Input.GetKeyUp (KeyCode.K)){
			miniIsFire = false;
		}

		if (Input.GetKeyDown(KeyCode.E)) { //weapon switcher
			i++; //switch to next index
			if (i > 2) {
				i = 0;
			}

			while (weaponCounter[i] == 0){	//while the next weapon isn't collected
				//Debug.Log("i = " + i);
				if (i > 2) { //loop around to the beginning
					i = 0;
				} 
				else {
					i += 1; //move to next position
					if (i > 2) { //loop around to the beginning
						i = 0;
					} 
				}
			}
			weaponIndex = i;
		} 

		else if (Input.GetKeyDown(KeyCode.Q)) { //weapon switcher
			Instantiate (reloadsound, transform.position, Quaternion.identity);
			i--; //switch to next index
			if (i < 0) {
				i = 2;
			}
			while (weaponCounter[i] == 0){	//while the next weapon isn't collected
				//Debug.Log("i = " + i);
				if (i < 0) { //loop around to the beginning
					i = 2;
				} 
				else {
					i -= 1; //move to previous position
					if (i < 0) { //loop around to the beginning
						i = 2;
					} 
				}
			}
			weaponIndex = i;
		}
	}

	void fire_greasegun(){
		if (Time.time - pistolCooldown > 0.3f) {
			Instantiate (psound, transform.position, Quaternion.identity);
			//sets temp to the grease gun so direction can be modified
			GameObject temp = Instantiate (weaponObjects[0], transform.position, Quaternion.identity);
			pistolCooldown = Time.time;
			if (!isForward) {//left
				temp.GetComponent<GreaseMove>().speed = -10;
				temp.GetComponent<SpriteRenderer>().flipX = true;
			} 
			else if (isForward) {//right
				temp.GetComponent<GreaseMove>().speed = 10;
			}
		}
	}

	void fire_rocket(){
		if (Time.time - rocketCooldown > 1.0f) {
			Instantiate (rsound, transform.position, Quaternion.identity);
			GameObject temp;
			if (!isForward) { //left
				temp = Instantiate (weaponObjects[1], transform.position + new Vector3(-1,0,0), Quaternion.Euler(0,180,0));
				//temp.GetComponent<SpriteRenderer>().flipX = true;
				temp.GetComponent<rocket> ().speed = 0.2f;
			}

			else{ //right
				temp = Instantiate (weaponObjects[1], transform.position + new Vector3(1,0,0), Quaternion.identity);
				temp.GetComponent<rocket> ().speed = 0.2f;
			}
			rocketCooldown = Time.time;
		}

	}

	void fire_minigun(){
		if (!miniIsFire) {
			miniIsFire = true;
			minigunSpool = Time.time;
			Instantiate (chargesound, transform.position, Quaternion.identity);
		}
		else{
			if (Time.time - minigunSpool > 0.8f) {
				if (Time.time - minigunCooldown > 0.1f && minigunOverheat < 100) {
					Instantiate (msound, transform.position, Quaternion.identity);
					minigunOverheat += 1;
					GameObject temp;
					if (!isForward) {//left
						float randfloat = Random.Range (-0.3f, 0.3f);
						temp = Instantiate (weaponObjects [2], transform.position + new Vector3 (0, randfloat, 0), Quaternion.identity);
						temp.GetComponent<SpriteRenderer> ().flipX = false;
						temp.GetComponent<MinigunMove> ().speed = -15;
					} else if (isForward) {//right
						float randfloat = Random.Range (-0.3f, 0.3f);
						temp = Instantiate (weaponObjects [2], transform.position + new Vector3 (0, randfloat, 0), Quaternion.identity);
						temp.GetComponent<MinigunMove> ().speed = 15;
					}
					minigunCooldown = Time.time;
				}
			}			

		}
	}


}


