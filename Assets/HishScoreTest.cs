﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HishScoreTest : MonoBehaviour {

	public int score;
	public string name = "kamu";
	int i = 0;


   	void OnGUI() {



		if (GUI.Button (new Rect (10, 80, 100, 30), "Add score: ")){

			HighScoreController.highscorecontroller.addScore(i, name);
			i++;

		}

		if (GUI.Button (new Rect (10, 160, 100, 30), "Save: " )) {

			HighScoreController.highscorecontroller.Save();
			
		}

		if (GUI.Button (new Rect (10, 200, 100, 30), "Load: " )) {
			
			HighScoreController.highscorecontroller.Load();
			
		}

	}
}