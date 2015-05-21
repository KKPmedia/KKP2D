using UnityEngine;
using System.Collections;

public class Statsmanager : MonoBehaviour {
	
	public GameObject stats;
	public GameObject menu;
	public GameObject statsm1;
	
	// Use this for initialization
	void Start () {
	
	}

	void Update() {
		stats.SetActive (true);
		menu.SetActive (false);
		statsm1.SetActive (false);
	}
}
