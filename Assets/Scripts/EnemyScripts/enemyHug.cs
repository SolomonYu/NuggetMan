using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHug : MonoBehaviour {
	GameObject Player;
	float playerx;
	public float speed;
	bool isStunned;


	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		speed = Random.Range (1f, 3f);
		InvokeRepeating ("ranMove", 0.2f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Player != null) {
			isStunned = gameObject.GetComponent<enemyTaken> ().isStunned;
			playerx = Player.transform.position.x;
			if (transform.position.x + 0.5f < playerx) {
				if (isStunned) {
					transform.Translate (new Vector2 (-speed * 5f, 0) * Time.deltaTime);
				} else {
					transform.Translate (new Vector2 (speed, 0) * Time.deltaTime);
				}

			} else if (transform.position.x - 0.5f > playerx) {
				if (isStunned) {
					transform.Translate (new Vector2 (speed * 5f, 0) * Time.deltaTime);
				} else {
					transform.Translate (new Vector2 (-speed, 0) * Time.deltaTime);
				}
			}
		}

	}
	void ranMove(){
		float updown = Random.Range (-1f, 1f);
		transform.Translate (new Vector2 (0, updown*speed) * Time.deltaTime);
	}
}
