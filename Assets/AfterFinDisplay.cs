using UnityEngine;
using System.Collections;

public class AfterFinDisplay : MonoBehaviour {

	public GameObject finDisplay;

	// Use this for initialization
	void Start () {
		finDisplay.SetActive (false);
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			finDisplay.SetActive (true);
		}
	}
}
