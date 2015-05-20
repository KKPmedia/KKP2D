using UnityEngine;
using System.Collections;

public class MountainEnable : MonoBehaviour {

	
	void OnEnable() {
		GameObject.FindGameObjectWithTag ("highscorecontrolerMountain").GetComponent<HighScoreLoadMountain> ().enabled = true;
	}
	void OnDisable() {
		GameObject.FindGameObjectWithTag ("highscorecontrolerMountain").GetComponent<HighScoreLoadMountain> ().enabled = false;
	}
}
