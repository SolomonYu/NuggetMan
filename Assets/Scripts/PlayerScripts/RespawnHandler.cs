using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnHandler : MonoBehaviour {
	public GameObject player;
	public GameObject playerprefab;
	public GameObject ui;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<Movement> ().health <= 0 || player == null) {
			ui.SetActive (true);
		}
	}


	public void onRespawn(){
		player = Instantiate (playerprefab, new Vector3 (0, 0, 0), Quaternion.identity);
	}
}
