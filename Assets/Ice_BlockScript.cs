﻿using UnityEngine;
using System.Collections;

public class Ice_BlockScript : MonoBehaviour {

	public GameObject player;
	public GameObject block1;
	public GameObject block2;
	public GameObject block3;

	private bool inAir;
	private float x = 3f;

	// Use this for initialization
	void Start () {
		//block1 = block1.GetComponent<GameObject> ();
		block1.SetActive (true);

		//block2 = block1.GetComponentInParent<GameObject> ();
		block2.SetActive (false);

		//block3 = block1.GetComponentInParent<GameObject> ();
		block3.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("Player") && inAir && player.GetComponent<Animator> ().GetBool ("isGrounded")) {
			inAir = false;

			if (x == 0) {
				Destroy(this.gameObject, 0f);
			}
			if (x == 1) {
				x--;
				block1.SetActive(false);
				block2.SetActive(false);
				block3.SetActive(true);
			}
			if (x == 2) {
				x--;
				block1.SetActive(false);
				block2.SetActive(true);
				block3.SetActive(false);
			}
			if (x == 3) {
				x--;
				block1.SetActive(true);
				block2.SetActive(false);
				block3.SetActive(false);
			}
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			inAir = true;
		}
	}
}
