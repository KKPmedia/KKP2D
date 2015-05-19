using UnityEngine;
using System.Collections;

public class ResetStats : MonoBehaviour {

	// Use this for initialization
	void Start () {
		HighScoreController._instance.ClearLeaderBoard ();
	}
}
