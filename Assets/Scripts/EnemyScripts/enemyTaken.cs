using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTaken : MonoBehaviour {
	public int health;
	int maxHealth;
	int pos;
	GameObject player;

	public GameObject minigunDrop;
	public GameObject FlamethrowerDrop;
	public GameObject HealthPack;

	public GameObject ouchsound;

	float stunTime;
	public bool isStunned;

	// Use this for initialization
	void Start () {
		maxHealth = health;
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		pos = gameObject.GetComponent<lanePos> ().pos;
		if (isStunned) {
			if (Time.time - stunTime > 0.01f) {
				isStunned = false;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D otherCollider){
		if (otherCollider.tag == "Pbullet" && otherCollider.GetComponent<lanePos> ().pos == pos) {
			int dmg = otherCollider.GetComponent<bulletStats> ().damage;
			health -= dmg;
			GameObject.Find ("DamageNumsHandler").GetComponent<DamageNumbers>().GenerateDamageNumbers(dmg, transform.position);
			isStunned = true;
			stunTime = Time.time;
			if (health <= 0) {
				if (player != null) {
					player.GetComponent<Movement> ().GreasePoints += maxHealth;
					player.GetComponent<Movement> ().EnemiesKilledTotal++;
				}
				Instantiate (ouchsound, transform.position, Quaternion.identity);
				ChanceToDrop ();
				Destroy (gameObject);
			}
		}
	}


	void ChanceToDrop(){
		int rnd = Random.Range (0, 100);
		if (rnd >= 50) {
			//nothing
		} else if (rnd < 50 && rnd >= 20) {
			Instantiate (HealthPack, transform.position, Quaternion.identity);
		} else if (rnd < 20 && rnd >= 10) {
			Instantiate (FlamethrowerDrop, transform.position, Quaternion.identity);
		} else if (rnd < 10) {
			Instantiate (minigunDrop, transform.position, Quaternion.identity);
		}
	}

}
