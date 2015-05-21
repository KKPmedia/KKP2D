using UnityEngine;
using System.Collections;

public class WastelandEnable : MonoBehaviour {


	void OnEnable() {
		GameObject.FindGameObjectWithTag ("highscorecontrolerWasteland").GetComponent<HighScoreLoadWasteland> ().enabled = true;
	}
	void OnDisable() {
		GameObject.FindGameObjectWithTag ("highscorecontrolerWasteland").GetComponent<HighScoreLoadWasteland> ().enabled = false;
	}
}
