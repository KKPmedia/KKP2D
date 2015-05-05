using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	public GameObject player;
	Vector3 player_pos;

	// Use this for initialization
	void Start () {
		player_pos = player.GetComponent<Transform> ().localPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		player.GetComponent<Transform> ().position = player_pos;
	}
}
