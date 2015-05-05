using UnityEngine;
using System.Collections;

public class Jungle_scene_switch : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D col){
		if (col.CompareTag ("Player")) {
			Application.LoadLevel(1);
		 }
		}
}
