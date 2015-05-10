using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	public GameObject player;

	private PlayerController pc;

	// Use this for initialization
	void Start () {
		pc = player.GetComponent<PlayerController> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			pc.dead();
		}
	}
}
