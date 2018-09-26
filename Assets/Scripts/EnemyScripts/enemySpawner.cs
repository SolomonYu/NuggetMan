using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
	public GameObject common;
	public GameObject common2;
	public GameObject rare;

	public bool bossAlive = false;

	float randflt;
	// Use this for initialization
	void Start () {
		randflt = Random.Range (5f, 10f);
		InvokeRepeating ("spawnEnemy", randflt, 6f);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Player")) {
			bossAlive = GameObject.Find ("Player").GetComponent<Movement> ().bossAlive;

			if (bossAlive) {
				//CancelInvoke ("spawnEnemy");
			}
		}
	}

	void spawnEnemy(){
		int ranint = Random.Range (1, 5);
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length < 25) {
			if (ranint == 1) {
				Instantiate (common, transform.position, Quaternion.identity);
			}
			if (ranint == 3 || ranint == 4) {
				Instantiate (common2, transform.position, Quaternion.identity);
			}
			if (ranint == 2) {
				Instantiate (rare, transform.position, Quaternion.identity);
			}
		}
	}
}
