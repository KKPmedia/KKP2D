using UnityEngine;
using System.Collections;

public class Attack_Script_Kong : MonoBehaviour {

	public GameObject player;
	Rigidbody2D player_rb;
	Animator anim; 
	Walk walk;
	float direction;
	public Vector2 forceAfterHit = new Vector2 (-10f, 0f);
	private Vector2 dir = new Vector2 (1f, 0f);
	private Vector2 movement;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		walk = this.GetComponent<Walk> ();
	}

	void FixedUpdate () {

	}

	void setDirection ()  {
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("attack_area")) {
			walk.enabled = false;
			anim.SetBool("attack", true);
			Invoke ("setAttackFalse", 0.5f);
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("attack_area")) {
			walk.enabled = false;
			anim.SetBool("attack", true);
			Invoke ("setAttackFalse", 0.5f);
		}
	}
	
	void OnTriggerExit2D (Collider2D col) {
		walk.enabled = true;
		anim.SetBool ("attack", false);
	}
	
	void setAttackFalse() {
		walk.enabled = true;
		anim.SetBool ("attack", false);
	}
	
	public bool isAttack () {
		if (anim.GetBool ("dead"))
			return false;
		return anim.GetBool ("attack");
	}
}
