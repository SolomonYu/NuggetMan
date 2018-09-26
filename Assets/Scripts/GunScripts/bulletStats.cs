using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletStats : MonoBehaviour {
	public int damage;
	int pos;

	public GameObject explosion;
	public GameObject explsound;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		pos = gameObject.GetComponent<lanePos> ().pos;

	}
	void OnTriggerEnter2D(Collider2D otherCollider){
		if (otherCollider.tag == "Enemy" && otherCollider.GetComponent<lanePos> ().pos == pos) {
			if (explosion != null) {
				Instantiate (explosion, transform.position, Quaternion.identity);
				Instantiate (explsound, transform.position, Quaternion.identity);
			}
			Destroy (gameObject);
		} else if (otherCollider.tag == "boss") {
			Destroy (gameObject);
		}
	}
	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
