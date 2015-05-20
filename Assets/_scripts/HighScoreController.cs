using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class HighScoreController: MonoBehaviour {
	
	public static HighScoreController highscorecontroller;

	public int leaderboardLength = 10;
	public int score;
	public string name;
	public List<Scores> highscores = new List<Scores> ();

	void Awake() {
		if (highscorecontroller == null) {
			DontDestroyOnLoad(gameObject);
			highscorecontroller = this;
		} else if (highscorecontroller != this) {
			Destroy(this.gameObject);
		}
	}

	public void addScore(int newPoint, string newName) {

		Scores newScore = new Scores (newPoint, newName);

		if (highscores.Count > 0) {

			//for (int i = 0; i < highscores.Count; i++) {
			foreach (Scores oldScores in highscores) {

				if (newScore.score > oldScores.score) {
					highscores.Insert(highscores.IndexOf(oldScores), newScore);
					break;
						//i++;
						//highscores.Add(newScore);
				}

				if (highscores.IndexOf(oldScores) == highscores.Count - 1) 
					highscores.Add (newScore);
			}
		} else {
			highscores.Add (newScore);
		}


	}

	public Scores getScoreatIndex(int i) {
		return (Scores)highscores[i];
	}

	public void Save() {

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "highScores.dat");

		//Scores scores = new Scores (score, name);
		//score.score = this.score;
		//score.name = this.name;
		//byte[] temp;
		//temp = new byte[highscores.Count];


		//for (int i = 0; i <; i++) {
		//	highscores.Add (Load ()[i]);
		//}
		//highscores.Add (scores);

		//for (int i = 1; i < highscores.Count; i++) {

		bf.Serialize (file, highscores);
		//}
		file.Close();
	}

	public void Load() {
		if (File.Exists (Application.persistentDataPath + "highScores.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "highScores.dat", FileMode.Open);
				
			//for (int i = 0; i < file.Length; i++)
			//while (file.Position != file.Length) {
			//	highscores.Add ((Scores)bf.Deserialize (file));
			//}
			this.highscores = (List<Scores>)bf.Deserialize (file); 
			//foreach (Scores score in highscores) {
			//	Debug.Log (score.name + "  " + score.score);
			//}
			//this.score = score.score;
			//this.name = score.name;

			file.Close ();
		}
	}
}

	[Serializable]
	public class Scores
	{
		public int score;
		public string name;

	public Scores (int score, string name) {
		this.score = score;
		this.name = name;
	}
	}


