using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HishScoreTest : MonoBehaviour {
	
	//string name="";
	//string score="";
	public Text name_disp;
	public Text scores_disp;
	string nametable;
	string scorestable;
	int i = 0;
	List<Scores> highscore;
	
	// Use this for initialization
	void Start () {
		//EventManager._instance._buttonClick += ButtonClicked;
		
		highscore = new List<Scores>();

		//HighScoreController._instance.ClearLeaderBoard ();
		highscore = HighScoreController._instance.GetHighScore(); 

		if (i == 0) {
			foreach (Scores _score in highscore) {
				nametable += _score.name + "\n";
				scorestable += _score.score + "\n";
				i++;
			}
		}
		i = 0;
		name_disp.text = nametable;
		scores_disp.text = scorestable;
	}

	
	// Update is called once per frame
	void Update () {

	}
}

