using UnityEngine;
using System.Collections;

public class HurtScript : MonoBehaviour {

	private PlayerController pc;
	public float damage = 2f;
	private Animator player_anim;

	int i = 0;
	
	// Use this for initialization
	void Start () {
		player_anim = this.GetComponentInParent<Animator> ();
		pc = this.GetComponentInParent<PlayerController> ();

	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("enemy")) {
			//damage = dino_red.GetComponent<AttackScript>().dino_red_bite_damage;
			Invoke ("main_char_hurt", 0.5f);
		}
	}

	void OnTriggerStay2D (Collider2D col) {

	}

	public void main_char_hurt() {
		if (i == 0) {
			pc.setHP (pc.getHP () - damage);
			player_anim.SetBool ("hurt", true);
			Invoke ("setHurtFalse", 1f);
			i++;
		}
	}

	void setHurtFalse() {
		player_anim.SetBool ("hurt", false);
		i = 0;
	}
}
