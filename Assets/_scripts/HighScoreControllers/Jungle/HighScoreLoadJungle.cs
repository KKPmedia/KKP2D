using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreLoadJungle : MonoBehaviour {

	private Text name;
	private Text scoretext;
	
	void OnEnable() {
		
		name = GameObject.FindGameObjectWithTag ("name_disp").GetComponent<Text> ();
		scoretext = GameObject.FindGameObjectWithTag ("score_disp").GetComponent<Text> ();

		HighScoreControllerJungle.highscorecontrollerJungle.Load ();
	}

	void Update() {
		name.text = "";
		scoretext.text = "";
		
		for (int i = 0; i < HighScoreControllerJungle.highscorecontrollerJungle.highscores.Count; i++) {
			Scores score = HighScoreControllerJungle.highscorecontrollerJungle.getScoreatIndex(i);
			
			name.text = name.text + score.name + "\n";
			scoretext.text = scoretext.text + score.score + "\n";
		}
	}
}