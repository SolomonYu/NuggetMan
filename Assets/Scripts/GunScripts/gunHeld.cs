using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunHeld : MonoBehaviour {
	public GameObject player;

	public Sprite pistol;
	public Sprite minigun;
	public Sprite rocket;

	int weaponIndex;
	//0 for pistol
	//1 for minigun
	//2 for rocket
	bool isForward;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		weaponIndex = player.GetComponent<Combat> ().weaponIndex;
		isForward = player.GetComponent<Movement> ().isForward;
		if (!isForward) {
			GetComponent<SpriteRenderer> ().flipX = true;
			transform.position = player.transform.position + new Vector3 (-0.6f, -0.2f,0);
		} else {
			GetComponent<SpriteRenderer> ().flipX = false;
			transform.position = player.transform.position + new Vector3 (0.6f, -0.2f,0);
		}
		if (weaponIndex == 0) {
			GetComponent<SpriteRenderer> ().sprite = pistol;
		}
		else if (weaponIndex == 2) {
			GetComponent<SpriteRenderer> ().sprite = minigun;
		}
		else if (weaponIndex == 1) {
			GetComponent<SpriteRenderer> ().sprite = rocket;
		}
	}
}
