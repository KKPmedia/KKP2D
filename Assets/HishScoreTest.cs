using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HishScoreTest : MonoBehaviour {

	public Text name_disp;
	public Text scores_disp;
	public bool update;
	string nametable;
	string scorestable;
	List<Scores> highscore;
	int x = 0;

	// Use this for initialization
	void Start() {
		//EventManager._instance._buttonClick += ButtonClicked;

	}

	void Update() {
		//EventManager._instance._buttonClick += ButtonClicked;
		if (update) {
			drawNew();
		}
	}

	public void setUpdate(bool x) {
		update = x;
	}

	private void drawNew() {
			
		update = false;
			highscore = new List<Scores> ();
			int i = highscore.Count;
			highscore = HighScoreController._instance.GetHighScore (); 
			
			foreach (Scores _score in highscore) {
				//if (en == true && x < i) {
				nametable += _score.name + "\n";
				scorestable += _score.score + "\n";
				x ++;
				//}
			}
		name_disp.text = nametable;
		scores_disp.text = scorestable;
	}
}

