using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggwardArm : MonoBehaviour {

	float timer = 0;
	public GameObject projectile;
	int i;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timer += 1;
		//Debug.Log (transform.rotation.eulerAngles.z);
		if (timer == 160) {

			if (transform.rotation.eulerAngles.z == 80) {
				//transform.rotation.eulerAngles.z = 80;
				StartCoroutine( moveDown(80) );
				StartCoroutine( wait () );
			}

			else if (transform.rotation.eulerAngles.z == 110) {
				//transform.rotation.eulerAngles.z = 80;
				Random.seed = System.DateTime.Now.Millisecond;
				i = Random.Range(1,40);
				print (i + " Seed");

				if (i % 2 == 0){
					StartCoroutine( moveUp(110) );
				}

				else{
					StartCoroutine( moveDown(110) );
				}
				//StartCoroutine( wait () );

			}


			else if (transform.rotation.eulerAngles.z == 140) {
				//transform.rotation.eulerAngles.z = 80;
				StartCoroutine( moveUp(140) );
				//StartCoroutine( wait () );
			
			}
			timer = 0;
		}
	}


	IEnumerator moveDown(int timer){
		int counter = 0;
		while (counter < 31) {
			transform.rotation = Quaternion.Euler(0f, 0f, timer);
			timer += 1;
			counter += 1;
			yield return new WaitForSeconds (.01f);
		}
		//shoot
		Instantiate(projectile, transform.Find("EggwardSpawn").position, Quaternion.identity);
//		yield return new WaitForSeconds (15f);
//		yield return null;
	}


	IEnumerator moveUp(int timer){
		int counter = 0;
		while (counter > -31) {
			transform.rotation = Quaternion.Euler (0f, 0f, timer);
			timer -= 1;
			counter -= 1;
			yield return new WaitForSeconds (.01f);
		}

		//shoot
		Instantiate(projectile, transform.Find("EggwardSpawn").position, Quaternion.identity);
	}

	IEnumerator wait(){
		yield return new WaitForSeconds (3f);
		yield return null;
	}
}
