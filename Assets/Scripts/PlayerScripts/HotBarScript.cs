using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBarScript : MonoBehaviour {

	public GameObject image1;
	public GameObject image2;
	public GameObject image3;
	public GameObject player;

	int selectedIndex;

	void Update () {
		selectedIndex = player.GetComponent<Combat> ().weaponIndex;

		if (selectedIndex == 0) {
			image1.GetComponent<Image>().color = new Color (255, 255, 255, 1);
			image2.GetComponent<Image>().color = new Color (255, 255, 255, .2f);
			image3.GetComponent<Image>().color = new Color (255, 255, 255, .2f);
		} else if (selectedIndex == 1) {
			image1.GetComponent<Image>().color = new Color (255, 255, 255, .2f);
			image2.GetComponent<Image>().color = new Color (255, 255, 255, 1);
			image3.GetComponent<Image>().color = new Color (255, 255, 255, .2f);
		} else {
			image1.GetComponent<Image>().color = new Color (255, 255, 255, .2f);
			image2.GetComponent<Image>().color = new Color (255, 255, 255, .2f);
			image3.GetComponent<Image>().color = new Color (255, 255, 255, 1);
		}

	}
}
