using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

	public float backgroundSize;
	public float yLocation;
	public float paralaxSpeed;

	private Transform cameraTransform;
	private int viewZone = 10;
	private Transform[] layers;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;

	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		layers = new Transform[transform.childCount]; //Script is put on the empty and we have 3 children that we need to grab
		for(int i = 0; i < transform.childCount; i++){
			layers [i] = transform.GetChild (i);
		}
		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = cameraTransform.position.x - lastCameraX;
		transform.position += Vector3.right * (deltaX * paralaxSpeed);
		lastCameraX = cameraTransform.position.x;
		if (cameraTransform.position.x < (layers [leftIndex].transform.position.x + viewZone)) {
			ScrollLeft ();
		}
		if (cameraTransform.position.x > (layers [rightIndex].transform.position.x - viewZone)) {
			ScrollRight ();
		}
//		if(Input.GetKeyDown(KeyCode.D))
//			ScrollRight();
//
//		if (Input.GetKeyDown (KeyCode.A))
//			ScrollLeft ();
	}


	void ScrollLeft(){
		layers[rightIndex].position = new Vector3(layers[leftIndex].position.x - backgroundSize, layers[leftIndex].position.y);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0) {
			rightIndex = layers.Length - 1;
		}

	}

	void ScrollRight(){
		layers[leftIndex].position = new Vector3(layers[rightIndex].position.x + backgroundSize,layers[leftIndex].position.y);
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length) {
			leftIndex = 0;
		}
	}
}
