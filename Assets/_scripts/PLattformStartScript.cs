using UnityEngine;
using System.Collections;

public class PLattformStartScript : MonoBehaviour {
	

	private Plattform_Side_Move sidemove;
	private Plattform_UpNDown_Move upndownmove;
	private Vector2 speed;

	// Use this for initialization
	void Start () {
		if (this.GetComponent<Plattform_Side_Move> () != null) {
			sidemove = this.GetComponent<Plattform_Side_Move> ();
			speed = sidemove.getSpeed();
			sidemove.enabled = false;
		}

		if (this.GetComponent<Plattform_UpNDown_Move> () != null) {
			upndownmove = this.GetComponent<Plattform_UpNDown_Move> ();
			speed = upndownmove.getSpeed();
			upndownmove.enabled = false;
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			if (this.GetComponent<Plattform_UpNDown_Move> () != null) {
				upndownmove.speed = speed;
				upndownmove.enabled = true;
			} else if (this.GetComponent<Plattform_Side_Move> () != null) {
				sidemove.speed = speed;
				sidemove.enabled = true;
			}
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (this.GetComponent<PlattformResetScript> () != null) {
			if (col.CompareTag ("Player")) {
				this.GetComponent<PlattformResetScript>().enabled = true;
			}
		}
	}
}
