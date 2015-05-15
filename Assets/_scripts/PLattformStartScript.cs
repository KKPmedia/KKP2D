using UnityEngine;
using System.Collections;

public class PLattformStartScript : MonoBehaviour {
	

	private Plattform_Side_Move sidemove;
	private Plattform_UpNDown_Move upndownmove;

	// Use this for initialization
	void Start () {
		if (this.GetComponent<Plattform_Side_Move> () != null) {
			sidemove = this.GetComponent<Plattform_Side_Move> ();
			sidemove.enabled = false;
		}
		if (this.GetComponent<Plattform_UpNDown_Move> () != null) {
			upndownmove = this.GetComponent<Plattform_UpNDown_Move> ();
			upndownmove.enabled = false;
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			if (this.GetComponent<Plattform_UpNDown_Move> () != null) {
				upndownmove.enabled = true;
			} else if (this.GetComponent<Plattform_Side_Move> () != null) {
				sidemove.enabled = true;
			}
		}
	}
}
