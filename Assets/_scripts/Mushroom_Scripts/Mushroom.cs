using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour {

	public GameObject player;
	Animator anim;
	float player_jumpforce;
	PlayerController pc;

	public float bounceForce = 1.2f;

	Walk walkScript;
	private float speed;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		pc = player.GetComponent<PlayerController> ();

		if (this.GetComponent<Walk> () != null) {
			walkScript = this.GetComponent<Walk> ();
			speed = walkScript.speed.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			anim.SetBool("standOn", true);
			pc.jumpForce = pc.jumpForce * bounceForce;
			if (this.GetComponent<Walk> () != null)
				walkScript.speed.x = 0;
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			anim.SetBool("standOn", true);
			if (this.GetComponent<Walk> () != null)
				walkScript.speed.x = 0;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			anim.SetBool ("standOn", false);
			pc.jumpForce = pc.jumpForce / bounceForce;
			if (this.GetComponent<Walk> () != null) {
			walkScript.enabled = true;
			walkScript.speed.x = speed;
			}
		}
	}
}
