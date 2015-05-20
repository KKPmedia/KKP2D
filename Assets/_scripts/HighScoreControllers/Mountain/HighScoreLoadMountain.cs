using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreLoadMountain : MonoBehaviour {
	
	private Text name;
	private Text scoretext;

	void OnEnable() {
		
		name = GameObject.FindGameObjectWithTag ("name_disp").GetComponent<Text>();
		scoretext = GameObject.FindGameObjectWithTag ("score_disp").GetComponent<Text> ();

		HighScoreControllerMountain.highscorecontrollerMountain.Load ();

		name.text = "";
		scoretext.text = "";
		
		for (int i = 0; i < HighScoreControllerMountain.highscorecontrollerMountain.highscores.Count; i++) {
			Scores score = HighScoreControllerMountain.highscorecontrollerMountain.getScoreatIndex(i);
			
			name.text = name.text + score.name + "\n";
			scoretext.text = scoretext.text + score.score + "\n";
		}
	}
}
