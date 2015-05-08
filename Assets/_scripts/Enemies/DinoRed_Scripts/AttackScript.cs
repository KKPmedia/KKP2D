using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {


	Animator anim; 
	Follow follow;

	public float dino_red_bite_damage = 2f;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		follow = this.GetComponent<Follow> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("attack_area")) {
			follow.enabled = false;
			anim.SetBool("attack", true);
			//Invoke ("setAttackFalse", 0.5f);
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		follow.enabled = true;
		anim.SetBool ("attack", false);
	}

	void setAttackFalse() {
		follow.enabled = true;
		anim.SetBool ("attack", false);
	}

	public bool isAttack () {
		if (anim.GetBool ("dead"))
			return false;
		return anim.GetBool ("attack");
	}
}
