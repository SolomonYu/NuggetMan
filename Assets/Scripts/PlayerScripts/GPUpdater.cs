using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPUpdater : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	 
	// Update is called once per frame
	void Update () {
		if(player != null)
			gameObject.GetComponent<Text>().text = "GP: " + player.GetComponent<Movement> ().GreasePoints;
	}
}
