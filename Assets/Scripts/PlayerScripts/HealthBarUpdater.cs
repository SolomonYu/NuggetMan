using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUpdater : MonoBehaviour {

	public GameObject player;
	float fullsize = 1;
	float hp = 20;
	float maxhp = 20;
	float healthPercent;
	float newsize;

	void Update () {
		if (player != null) {
			hp = player.GetComponent<Movement> ().health;
			maxhp = player.GetComponent<Movement> ().MaxHealth;
			healthPercent = hp / maxhp;
			newsize = fullsize * healthPercent;
			transform.localScale = new Vector3 (Mathf.Clamp (newsize, 0f, 1f), 1, 1);		
		} else {
			transform.localScale = new Vector3 (Mathf.Clamp (0, 0f, 1f), 1, 1);
		}
	}
}
