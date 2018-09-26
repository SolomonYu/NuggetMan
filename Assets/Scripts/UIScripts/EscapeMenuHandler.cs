using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenuHandler : MonoBehaviour {
	public GameObject escMenu;
	bool visible = false;
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (visible) {
				escMenu.SetActive (false);
				visible = false;
			} else {
				escMenu.SetActive (true);
				visible = true;
			}
		}
	}
}
