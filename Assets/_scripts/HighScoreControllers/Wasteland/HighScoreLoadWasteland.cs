using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreLoadWasteland : MonoBehaviour {

	public Text name;
	public Text scoretext;

	private string namestring;
	private string scorestring;

	void OnEnable() {

		HighScoreControllerWasteland.highscorecontrollerWasteland.Load ();

		name.text = "";
		scoretext.text = "";

		for (int i = 0; i < HighScoreControllerWasteland.highscorecontrollerWasteland.highscores.Count; i++) {
			Scores score = HighScoreControllerWasteland.highscorecontrollerWasteland.getScoreatIndex(i);

			name.text = name.text + score.name + "\n";
			scoretext.text = scoretext.text + score.score + "\n";
		}
	}
}
