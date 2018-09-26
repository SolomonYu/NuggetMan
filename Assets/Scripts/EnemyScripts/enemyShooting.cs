using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour {
	bool ENEMYSPOTTED;
	public GameObject bullet;
	GameObject Player;
	float playerx;
	bool faceLeft;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("shootBullet", Random.Range (.2f, 5f), 8f);
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Player != null) {
			playerx = Player.transform.position.x;
			if (transform.position.x + 0.5f < playerx) {
				faceLeft = true;
				transform.rotation = Quaternion.Euler (0f, 180f, 0f);
			} else if (transform.position.x - 0.5f > playerx) {
				faceLeft = false;
				transform.rotation = Quaternion.Euler (0f, 0f, 0f);
			}
		}
		
	}
	void OnBecameVisible(){
		ENEMYSPOTTED = true;
	}
	void OnBecameInvisible(){
		ENEMYSPOTTED = false;
	}
	void shootBullet(){
		if (ENEMYSPOTTED) {
			GameObject shot;
			shot = Instantiate (bullet, transform.position, Quaternion.identity);
			if (faceLeft){
				shot.transform.rotation = Quaternion.Euler (0f, 180f, 0f);
			}

		}

	}
}
