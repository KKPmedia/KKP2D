using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreLoad : MonoBehaviour {

	public Text entry;
	
	// Update is called once per frame
	void Update () {
		entry.text = PlayerPrefs.GetString ("Name") + "    " + PlayerPrefs.GetString ("TimeWasteland") + "     " + 
			PlayerPrefs.GetInt ("MoneyWasteland");
	}
}
