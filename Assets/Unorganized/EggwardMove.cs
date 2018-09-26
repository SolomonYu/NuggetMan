using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggwardMove : MonoBehaviour {

	public float speed = -5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector2 (speed, 0) * Time.deltaTime);
	}
}
