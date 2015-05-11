using UnityEngine;
using System.Collections;

public class Desert_scene_loader: MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D col){
		if (col.CompareTag ("Player")) {
			Application.LoadLevel(4);
		}
	}
}
