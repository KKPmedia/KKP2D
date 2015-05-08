using UnityEngine;
using System.Collections;

public class Meat_fulture_rip : MonoBehaviour {

	private bool ripped;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("enemy")) {
			destroy ();
		}

		if (col.CompareTag ("Player") && ripped == false) {
			destroy ();
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("enemy")) {
			ripped = true;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.CompareTag ("enemy")) {
			ripped = false;
		}
	}

	void destroy () {
		Destroy (this.gameObject, 0f);
	}
}
