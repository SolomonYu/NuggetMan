using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagerNumbersUp : MonoBehaviour {
	Vector2 startPosition;
	public int YSPEED = 4;
	public float MAXDISTANCE = 2;
	public float fadeIncrement = .01f;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector2(0, YSPEED) * Time.deltaTime);
		float Distance = Mathf.Abs (startPosition.y) - Mathf.Abs (transform.position.y);
		Distance = Mathf.Abs (Distance);
		if (Distance > MAXDISTANCE) {
			Destroy (gameObject);
		}
	}
}
