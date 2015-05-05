using UnityEngine;
using System.Collections;

public class TimerStart : MonoBehaviour {

	public TimerStart timerText;


	// Use this for initialization
	void Start () {
		timerText = timerText.GetComponent<TimerStart> ();
		//timerText.
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag("Player")) {
			//timerstart.enabled = true;
		}
	}
}
