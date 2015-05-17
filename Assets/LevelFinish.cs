using UnityEngine;
using System.Collections;

public class LevelFinish : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			PlayerPrefs.SetString ("Level", "Mountain");
		//	PlayerPrefs.SetString ("Time", Timer.getTime ());
		//	PlayerPrefs.SetFloat ("Coins", CoinScript.getCoins ());
		}
	}
}