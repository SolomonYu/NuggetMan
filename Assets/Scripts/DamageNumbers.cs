using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumbers : MonoBehaviour {

	public GameObject DamageNumbersPrefab;
	public GameObject Number;
	public Sprite[] Numbers;

 	public void GenerateDamageNumbers(int Damage, Vector3 Position){

		string strDmg = Damage + "";

		GameObject TempStorageDmgNum = Instantiate (DamageNumbersPrefab, Position, Quaternion.identity);

		for (int i = 0; i < strDmg.Length; i++) {
			char idx = strDmg[0];
			int index = int.Parse(idx.ToString());
			GameObject num = Instantiate (Number, Position, Quaternion.identity);
			num.GetComponent<SpriteRenderer> ().sprite = Numbers [index];
			num.transform.parent = TempStorageDmgNum.transform;
		}

	}
}
