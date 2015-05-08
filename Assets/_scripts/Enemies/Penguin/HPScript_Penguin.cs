using UnityEngine;
using System.Collections;

public class HPScript_Penguin : MonoBehaviour {

	public float hp = 4;
	public float main_bullett_damage = 2;
	public float slash_damage = 5;
	public GameObject player;
	public float slash_delay = 1.5f;
	
	private float direction;
	private Animator enemy_anim;
	private Animator player_anim;
	private int i = 0;
	private float next_slash = 0;
	private bool slash = false;
	
	// Use this for initialization
	void Start () {
		enemy_anim = this.GetComponent<Animator> ();
		//player = player.GetComponent<GameObject> ();
		player_anim = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (hp < 1) {
			holdOn();
			enemy_anim.SetBool ("dead", true);
			destroy();
		}
		
		if (player_anim.GetBool ("slash")) {
			slash = true;
		} else {
			slash = false;
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("main_bullett")) {
			if (i == 0) {
				hp -= main_bullett_damage;
				Invoke ("delay", 0.2f);
				i++;
			}
		}
	}
	
	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("slash_area") && slash) {
			//if (col.CompareTag ("slash_area") && player_anim.GetBool ("slash") && Time.time > next_slash) {
			next_slash = Time.time + slash_delay;
			hp -= slash_damage;
			Invoke ("setHurtFalse", 0.5f);
		}
	}
	
	void holdOn () {
		if (this.GetComponent<Follow>() != null)
			this.GetComponent<StartStopMoveScript>().stopFollowScript();
		if (this.GetComponent<Walk>() != null)
			this.GetComponent<StartStopMoveScript>().stopWalkScript();
	}

	void delay () {
		i = 0;
	}

	void destroy() {
		Destroy (this.gameObject, 1f);
	}
}

