using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishDisplayScores : MonoBehaviour {


	public Text neededTime;
	public int allCoins;
	public Text earnedMoney;
	public Text score;

	//public HUD_UI hud;
	private SaveWasteland sw;
	private Timer t; 

	// Use this for initialization
	void Start () {
		stop ();
	}


	void stop() {
		Time.timeScale = 0;
	}

	void Update() {
		earnedMoney.text = PlayerPrefs.GetString ("Money") + "/" + allCoins.ToString();
		neededTime.text = PlayerPrefs.GetString ("Time");
		score.text = PlayerPrefs.GetInt ("Score").ToString();
	}
}
