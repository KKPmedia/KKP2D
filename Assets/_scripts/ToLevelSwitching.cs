using UnityEngine;
using System.Collections;

public class ToLevelSwitching : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col){
		if (col.CompareTag ("Player")) {
			Application.LoadLevel(1);
		}
	}
}
