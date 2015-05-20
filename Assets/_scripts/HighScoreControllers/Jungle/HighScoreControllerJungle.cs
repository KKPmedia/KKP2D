using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class HighScoreControllerJungle : MonoBehaviour {
		
		public static HighScoreControllerJungle highscorecontrollerJungle;
		
		public int leaderboardLength = 10;
		public int score;
		public string name;
		public List<Scores> highscores = new List<Scores> ();
		
		void Awake() {
			if (highscorecontrollerJungle == null) {
				DontDestroyOnLoad(gameObject);
				highscorecontrollerJungle = this;
			} else if (highscorecontrollerJungle != this) {
				Destroy(this.gameObject);
			}
		}
		
		public void addScore(int newPoint, string newName) {
			
			Scores newScore = new Scores (newPoint, newName);
			
			if (highscores.Count > 0) {
				foreach (Scores oldScores in highscores) {
					
					if (newScore.score > oldScores.score) {
						highscores.Insert(highscores.IndexOf(oldScores), newScore);
						break;
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
			FileStream file = File.Create (Application.persistentDataPath + "highScoresJungle.dat");
			
			bf.Serialize (file, highscores);
			
			file.Close();
		}
		
		public void Load() {
			if (File.Exists (Application.persistentDataPath + "highScoresJungle.dat")) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (Application.persistentDataPath + "highScoresJungle.dat", FileMode.Open);
				
				this.highscores = (List<Scores>)bf.Deserialize (file); 
				
				file.Close ();
			}
		}
	public void Clear() {
		highscores.Clear ();
		Save ();
	}
}
	//[Serializable]
	//public class Scores
	//{
	//	public int score;
	//	public string name;
	
	//	public Scores (int score, string name) {
	//		this.score = score;
	//		this.name = name;
	//	}
	//}
