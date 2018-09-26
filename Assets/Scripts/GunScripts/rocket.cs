using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {
	public float speed;
	float storespeed;
	// Use this for initialization
	void Start () {
		storespeed = speed;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (speed, 0) * Time.deltaTime);
		speed += storespeed * 1.5f;


	}
}
