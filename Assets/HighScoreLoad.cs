using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreLoad : MonoBehaviour {

	public Text name;
	public Text scoretext;

	private string namestring;
	private string scorestring;

	void OnEnable() {
		name.text = "";
		scoretext.text = "";

		for (int i = 0; i < HighScoreController.highscorecontroller.highscores.Count; i++) {
			Scores score = HighScoreController.highscorecontroller.getScoreatIndex(i);

		//	namestring = 

			name.text = name.text + score.name + "\n";
			scoretext.text = scoretext.text + score.score + "\n";
		}
	}
}
