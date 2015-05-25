using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	//public GameObject player;

	private PlayerController pc;
	private bool alive;

	// Use this for initialization
	void Start () {
		pc = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		alive = pc.isAlive ();
	}

	void OnTriggerEnter2D (Collider2D col) {

		if (col.CompareTag ("Player") && alive) {
			pc.setDead();
		}
	}
}
