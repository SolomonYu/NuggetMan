using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
	public GameObject box;
	public Text text;

	public bool dialogueActive;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogueActive && Input.GetKeyDown(KeyCode.E)) {
			box.SetActive (false);
			dialogueActive = false;
		}
		
	}
	public void showBox(string dialogue){
		dialogueActive = true;
		box.SetActive (true);
		text.text = dialogue;
	}
}
