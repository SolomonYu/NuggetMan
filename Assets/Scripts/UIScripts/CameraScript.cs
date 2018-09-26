using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private GameObject Player;
	Vector3 velocity = Vector3.zero;
	public float smoothTime = .15f;
	private Vector3 newTarget;
	Vector3 placeholderPos;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Player != null) {
			placeholderPos = Vector3.SmoothDamp (transform.position, GameObject.Find ("Player").transform.position, ref velocity, smoothTime);
			transform.position = new Vector3 (placeholderPos.x, 0f);
		}
	}
}
