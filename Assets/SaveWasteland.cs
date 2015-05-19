using UnityEngine;
using System.Collections;
using System.IO;

public class SaveWasteland : MonoBehaviour {

	public float coin_mul = 2.5f;

	private string name;
	private float money;
	private int time;
	private float score;

	void OnTriggerEnter2D (Collider2D col) {

		name = PlayerPrefs.GetString ("Name");

		if (col.CompareTag ("Player")) {
			time = Timer.getMin();

			if (time < 2) 
				score = 4500f;
			else if (time > 2 && time < 3)
				score = 4000f;
			else if (time > 3 && time < 4)
				score = 3500f;
			else if (time > 4 && time < 5)
				score = 3000f;
			else if (time > 5)
				score = 2000f;

			money = HUD_UI.money;

			score = score + money * coin_mul;

			HighScoreController._instance.SaveHighScore(name,System.Int32.Parse(score.ToString()));
		}
	}
}