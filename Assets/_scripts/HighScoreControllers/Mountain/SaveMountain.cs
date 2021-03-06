﻿using UnityEngine;
using System.Collections;
using System.IO;

public class SaveMountain : MonoBehaviour {
	
	
	public int coin_mul = 2;
	public PlayerController player;
	
	private string name;
	private float money;
	private string money_s;
	private int money_i;
	private int time;
	private int score;
	private int i, lives;


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
		//lives = int.Parse (player.getLives ().ToString());
		time = Timer.getMin();
		
		if (time < 2) 
			score = 4500;
		else if (time > 2 && time < 3)
			score = 4000;
		else if (time > 3 && time < 4)
			score = 3500;
		else if (time > 4 && time < 5)
			score = 3000;
		else if (time > 5)
			score = 2000;
		
		money = HUD_UI.money;
		
		money_s = money.ToString();
		money_i = int.Parse(money_s);
		score = score + money_i * coin_mul;
		HighScoreControllerMountain.highscorecontrollerMountain.Load ();		
		HighScoreControllerMountain.highscorecontrollerMountain.addScore(score, name);
		HighScoreControllerMountain.highscorecontrollerMountain.Save ();

		PlayerPrefs.SetString ("Time", Timer.getNeededTime());
		PlayerPrefs.SetString ("Money", (money_i / 15).ToString());
		PlayerPrefs.SetInt ("Score", score);
	}

	public string getScore() {
		return score.ToString ();
	}
}