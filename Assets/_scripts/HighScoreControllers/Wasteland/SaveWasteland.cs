﻿using UnityEngine;
using System.Collections;
using System.IO;

public class SaveWasteland : MonoBehaviour {

	public PlayerController player;
	public int coin_mul = 2;

	private string name;
	private float money;
	private string money_s;
	private int money_i;
	private int time;
	private int score;
	private int i = 0, lives;


	void Start() {
		name = PlayerPrefs.GetString ("Name");
		PlayerPrefs.DeleteAll ();
	}

	void Update() {

		if (i > 0) {

			save ();
		}
	}

	void OnTriggerEnter2D (Collider2D col) {

		if (col.CompareTag ("Player")) {
			i = 1;
		}
	}

	void save() {
		i = 0;

		time = Timer.getMin();

		if (time < 2) 
			score = 4500;
		if (time > 2 && time < 3)
			score = 4000;
		if (time > 3 && time < 4)
			score = 3500;
		if (time > 4 && time < 5)
			score = 3000;
		if (time > 5)
			score = 2000;

		money = HUD_UI.money;

		money_s = money.ToString();
		money_i = int.Parse(money_s);
		score = score + money_i * coin_mul;


		HighScoreControllerWasteland.highscorecontrollerWasteland.Load ();
		HighScoreControllerWasteland.highscorecontrollerWasteland.addScore(score, name);
		HighScoreControllerWasteland.highscorecontrollerWasteland.Save ();

		PlayerPrefs.SetString ("Time", Timer.getNeededTime());
		PlayerPrefs.SetString ("Money", (money_i / 15).ToString());
		PlayerPrefs.SetInt ("Score", score);
	}

	public string getScore() {
		return score.ToString ();
	}
}