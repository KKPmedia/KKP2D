using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour {

	public GameObject text_field;
	
	void Update() {
			PlayerPrefs.SetString ("Name", text_field.GetComponent<Text> ().text);
	}
}
