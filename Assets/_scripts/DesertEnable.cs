using UnityEngine;
using System.Collections;

public class DesertEnable : MonoBehaviour {

	void OnEnable() {
		GameObject.FindGameObjectWithTag ("highscorecontrolerDesert").GetComponent<HighScoreLoadDesert> ().enabled = true;
	}
	void OnDisable() {
		GameObject.FindGameObjectWithTag ("highscorecontrolerDesert").GetComponent<HighScoreLoadDesert> ().enabled = false;
	}
}
