using UnityEngine;
using System.Collections;

public class ResetScores : MonoBehaviour {


	void OnEnable() {
		HighScoreControllerDesert.highscorecontrollerDesert.Clear ();
		HighScoreControllerJungle.highscorecontrollerJungle.Clear ();
		HighScoreControllerMountain.highscorecontrollerMountain.Clear ();
		HighScoreControllerWasteland.highscorecontrollerWasteland.Clear ();

		Invoke ("disable", 1f);
	}

	void disable() {
		this.enabled = false;
	}
}
