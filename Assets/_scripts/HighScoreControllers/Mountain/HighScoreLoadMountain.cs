using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreLoadMountain : MonoBehaviour {
	
	public Text name;
	public Text scoretext;
	
	private string namestring;
	private string scorestring;
	
	void OnEnable() {
		
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
