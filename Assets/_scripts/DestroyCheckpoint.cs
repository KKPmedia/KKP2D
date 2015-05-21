using UnityEngine;
using System.Collections;

public class DestroyCheckpoint : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			Destroy (this.gameObject);
		}
	}
}
