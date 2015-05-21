using UnityEngine;
using System.Collections;

public class Statsmanger1 : MonoBehaviour {

	public GameObject stats;
	public GameObject menu;
	public GameObject statsm;
	
	// Use this for initialization
	void Start () {

	}

	void Update () {
		stats.SetActive (false);
		menu.SetActive (true);
		statsm.SetActive (false);
	}
}
