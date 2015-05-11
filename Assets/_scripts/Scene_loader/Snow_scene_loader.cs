using UnityEngine;
using System.Collections;

public class Snow_scene_loader : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D col){
		if (col.CompareTag ("Player")) {
			Application.LoadLevel(5);
		}
	}
}