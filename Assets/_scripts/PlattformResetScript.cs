using UnityEngine;
using System.Collections;

public class PlattformResetScript : MonoBehaviour {

	private Vector2 startPos;
	private bool standOn;
	private float turntoleft;

	// Use this for initialization
	void Start () {
		startPos = new Vector2 (this.GetComponent<Transform> ().position.x, this.GetComponent<Transform> ().position.y);
		standOn = true;

		turntoleft = this.GetComponent<Transform> ().position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (!standOn) {
			if (this.GetComponent<Plattform_UpNDown_Move>() != null) {
				if (this.GetComponent<Transform>().position.y == startPos.y) {
					this.GetComponent<Plattform_UpNDown_Move>().speed.y = 0;
					this.enabled = false;
				}
			} 

			if (this.GetComponent<Plattform_Side_Move>() != null) {
				if (this.GetComponent<Transform>().position.x > (turntoleft - 0.5f)) {
					this.GetComponent<Plattform_Side_Move>().speed.x = 0;
					this.enabled = false;
				}
			}
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			standOn = false;
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			standOn = true;
		}
	}
}
