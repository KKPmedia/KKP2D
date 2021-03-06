﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreLoadWasteland : MonoBehaviour {

	private Text name;
	private Text scoretext;

	void OnEnable() {

		name = GameObject.FindGameObjectWithTag ("name_disp").GetComponent<Text> ();
		scoretext = GameObject.FindGameObjectWithTag ("score_disp").GetComponent<Text> ();

		HighScoreControllerWasteland.highscorecontrollerWasteland.Load ();
	}

	void Update() {
		name.text = "";
		scoretext.text = "";

		for (int i = 0; i < HighScoreControllerWasteland.highscorecontrollerWasteland.highscores.Count; i++) {
			Scores score = HighScoreControllerWasteland.highscorecontrollerWasteland.getScoreatIndex(i);

			name.text = name.text + score.name + "\n";
			scoretext.text = scoretext.text + score.score + "\n";
		}
	}
}
