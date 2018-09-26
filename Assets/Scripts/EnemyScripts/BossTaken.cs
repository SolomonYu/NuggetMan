using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTaken : MonoBehaviour {
	public int health;
	int maxHealth;

	public float fullsize = 1f;

	GameObject player;
	public GameObject bossUIHealthBar;

	float stunTime;
	public bool isStunned;

	// Use this for initialization
	void Start () {
		maxHealth = health;
		player = GameObject.Find ("Player");
		//bossUIHealthBar = GameObject.Find("BossUI").transform.Find ("BG").Find ("Bar").gameObject;
	}

	// Update is called once per frame
	void Update () {
		if (isStunned) {
			if (Time.time - stunTime > 0.01f) {
				isStunned = false;
			}
		}
		
		float healthPercent = health / maxHealth;
		float newsize = fullsize * healthPercent;
		bossUIHealthBar.transform.localScale = new Vector3 (Mathf.Clamp (newsize, 0f, 1f), 1, 1);

	}

	void OnTriggerEnter2D(Collider2D otherCollider){
		if (otherCollider.tag == "Pbullet") {
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
				player.GetComponent<Movement> ().bossAlive = false;
				player.GetComponent<Movement> ().EnemiesKilledTotal = -100;
				Destroy (gameObject);
			}
		}
	}

}
