using UnityEngine;
using System.Collections;

public class HP_Script_Snowman : MonoBehaviour {


	public float hp = 20;
	public float main_bullett_damage = 2;
	public float slash_damage = 5;
	public GameObject player;
	public float slash_delay = 0.5f;

	private Animator enemy_anim;
	private Animator player_anim;
	private int i = 0;
	private float next_slash = 0;
	
	// Use this for initialization
	void Start () {
		enemy_anim = this.GetComponent<Animator> ();
		//player = player.GetComponent<GameObject> ();
		player_anim = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (hp < 1) {
			this.GetComponent<Snowman>().enabled = false;
			enemy_anim.SetBool ("dead", true);
			destroy();
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("main_bullett")) {
			if (i == 0) {
				hp -= main_bullett_damage;
				Invoke ("delay", 0.5f);
				i++;
			}
		}

		if (col.CompareTag ("slash_area") && player_anim.GetBool ("slash") && Time.time > next_slash) {
			next_slash = Time.time + slash_delay;
			hp -= slash_damage;
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("slash_area") && player_anim.GetBool ("slash") && Time.time > next_slash) {
			next_slash = Time.time + slash_delay;
			hp -= slash_damage;
		}
	}

	void delay () {
		i = 0;
	}
	
	void destroy() {
		Destroy (this.gameObject, 2f);
	}
}

