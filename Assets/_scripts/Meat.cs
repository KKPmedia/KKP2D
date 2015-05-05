using UnityEngine;
using System.Collections;

public class Meat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag("Player"))
			this.gameObject.SetActive (false);
	}
}
