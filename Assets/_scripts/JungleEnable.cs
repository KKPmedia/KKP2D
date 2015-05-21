using UnityEngine;
using System.Collections;

public class JungleEnable : MonoBehaviour {

	void OnEnable() {
		GameObject.FindGameObjectWithTag ("highscorecontrolerJungle").GetComponent<HighScoreLoadJungle> ().enabled = true;
	}
	void OnDisable() {
		GameObject.FindGameObjectWithTag ("highscorecontrolerJungle").GetComponent<HighScoreLoadJungle> ().enabled = false;
	}
}
