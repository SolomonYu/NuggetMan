using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startText : MonoBehaviour {
	public string dialogue;
	DialogueManager manager;
	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<DialogueManager> ();
		dialogue = "Controls: K to shoot, WASD, Q for prev weapon, E for next weapon. Pick up weapons off the floor. find health packs. Kill eggward";
		manager.showBox (dialogue);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
