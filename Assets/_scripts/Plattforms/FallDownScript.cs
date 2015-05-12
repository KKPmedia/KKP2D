using UnityEngine;
using System.Collections;

public class FallDownScript : MonoBehaviour {

	public Animator player_anim;
	public GameObject plattformer_ground_go;
	private EdgeCollider2D plattformer_ground_col; 


	// Use this for initialization
	void Start () {
		player_anim = player_anim.GetComponent<Animator> ();
		plattformer_ground_col = plattformer_ground_go.GetComponent<EdgeCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("Player") && Input.GetAxis("Vertical") != 0) {
			plattformer_ground_col.enabled = false;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		plattformer_ground_col.enabled = true;
	}
}
