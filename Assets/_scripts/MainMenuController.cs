using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	public GameObject stats;
	public GameObject menu;

	// Use this for initialization
	void Start () {
		stats.SetActive (false);
		menu.SetActive (true);
	}
}
