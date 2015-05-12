using UnityEngine;
using System.Collections;

public class Plant_AttackScript : MonoBehaviour {

	public BoxCollider2D hurt_area;
	public bool isFlip = false;
	public Transform player;

	Animator anim; 
	int i = 0;
	//Follow follow;
	
	//public float dino_red_bite_damage = 2f;
	
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		hurt_area.enabled = false;

	//	follow = this.GetComponent<Follow> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("attack_area")) {
			if (isFlip) {
				if (player.localPosition.x > this.GetComponent<Transform>().localPosition.x && this.GetComponent<Transform>().localScale.x < 0)
					flip();
				if (player.localPosition.x < this.GetComponent<Transform>().localPosition.x && this.GetComponent<Transform>().localScale.x > 0)
					flip();
			}

			hurt_area.enabled = true;
			anim.SetBool("attack", true);
			Invoke ("setAttackFalse", 0.5f);
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("attack_area") && i == 0) {
			hurt_area.enabled = true;
			anim.SetBool("attack", true);
			Invoke ("setAttackFalse", 0.5f);
			i++;
		}
	}
	
	void OnTriggerExit2D (Collider2D col) {
		hurt_area.enabled = false;
		anim.SetBool ("attack", false);
		i = 0;
	}
	
	void setAttackFalse() {
		hurt_area.enabled = false;
		i = 0;
		anim.SetBool ("attack", false);
	}
	
	public bool isAttack () {
		if (anim.GetBool ("dead"))
			return false;
		return anim.GetBool ("attack");
	}

	void flip () {
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;

		Vector3 position = transform.localPosition;
		if (this.GetComponent<Transform>().localScale.x < 0)
			position.x += 1;
		if (this.GetComponent<Transform>().localScale.x > 0)
			position.x -= 1;

		transform.localPosition = position;
		transform.localScale = theScale;
	}
}