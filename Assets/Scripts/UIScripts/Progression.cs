using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progression : MonoBehaviour {

	int Points;
	bool menuOpen = false;
	public GameObject MenuGUI;
	public GameObject GreasePointsText;
	public GameObject HPText;
	public GameObject DEFText;
	public GameObject SPDText;
	public GameObject DMGText;
	public int HPBought = 0;
	public int DEFBought = 0;
	public int DMGBought = 0;
	public int SPDBought = 0;
	public int HPPrice = 100;
	public int DEFPrice = 100;
	public int SPDPrice = 100;
	public int DMGPrice = 100;

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null)
			Points = player.GetComponent<Movement> ().GreasePoints;

		if (Input.GetKeyDown (KeyCode.I)) {
			if (!menuOpen) {
				SkillsMenu (true);
				menuOpen = true;
			} else {
				SkillsMenu (false);
				menuOpen = false;
			}
		}

		HPText.GetComponent<Text> ().text = HPPrice + "";
		DMGText.GetComponent<Text> ().text = DMGPrice + "";
		SPDText.GetComponent<Text> ().text = SPDPrice + "";
		DEFText.GetComponent<Text> ().text = DEFPrice + "";
		GreasePointsText.GetComponent<Text> ().text = Points + "";
	}


	void SkillsMenu(bool open){
		if (open) {
			MenuGUI.SetActive (true);
		} else {
			MenuGUI.SetActive (false);
		}
	}

	public void OnHP(){
		if (Points < HPPrice)
			return;
		HPBought++;
		player.GetComponent<Movement> ().GreasePoints -= HPPrice;
		HPPrice += (HPBought * (HPPrice / 5));
		GameObject.Find ("Player").GetComponent<Movement> ().MaxHealth += 10;
	}
	public void OnDEF(){
		if (Points < DEFPrice)
			return;
		DEFBought++;
		player.GetComponent<Movement> ().GreasePoints -= DEFPrice;
		DEFPrice += (DEFBought * (DEFPrice / 5));
		GameObject.Find ("Player").GetComponent<Movement> ().defense += .1f;
	}
	public void OnSPD(){
		if (Points < SPDPrice)
			return;
		SPDBought++;
		player.GetComponent<Movement> ().GreasePoints -= SPDPrice;
		SPDPrice += (SPDBought * (SPDPrice / 5));
		GameObject.Find ("Player").GetComponent<Movement> ().speed += .1f;
	}
	public void OnDMG(){
		if (Points < DMGPrice)
			return;
		DMGBought++;  
		player.GetComponent<Movement> ().GreasePoints -= DMGPrice;
		DMGPrice += (DMGBought * (DMGPrice / 5));
		GameObject.Find ("Player").GetComponent<Movement> ().damageMulti += 0.1f;
	}
}
