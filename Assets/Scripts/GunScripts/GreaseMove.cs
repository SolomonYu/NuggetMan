using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreaseMove : MonoBehaviour {
	public float speed = 10.0f;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (speed, 0) * Time.deltaTime);


	}
}
