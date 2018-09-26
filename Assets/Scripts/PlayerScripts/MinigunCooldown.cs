using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigunCooldown : MonoBehaviour {

	public float percentage;
	public GameObject player;

	// Use this for initialization
	void Start () {
		percentage = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			percentage = player.GetComponent<Combat> ().minigunOverheat;
			if (percentage == 0) {
				GetComponent<Text> ().text = "";
			} else {
				percentage = Mathf.Ceil (percentage);
				percentage = Mathf.Clamp (percentage, 0, 100);
				GetComponent<Text> ().text = percentage + "%";
			}
		}
	}
}
