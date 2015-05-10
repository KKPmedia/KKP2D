using UnityEngine;
using System.Collections;

public class HP_Script_Fulture : MonoBehaviour {

	public float hp = 5;
	public float main_bullett_damage = 2;
	public float slash_damage = 5;
	public GameObject player;
	public float slash_delay = 1.5f;
	public Transform meatSpawn;
	public GameObject meat;
	
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
			enemy_anim.SetBool ("dead", true);
			holdOn();
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
				holdOn();
				hp -= main_bullett_damage;
				Invoke ("setHurtFalse", 0.5f);
				i++;
			}
		}
		if (col.CompareTag ("slash_area") && slash) {
			next_slash = Time.time + slash_delay;
			holdOn();
			hp -= slash_damage;
			Invoke ("setHurtFalse", 0.5f);
		}
	}
	
	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("slash_area") && slash) {
			//if (col.CompareTag ("slash_area") && player_anim.GetBool ("slash") && Time.time > next_slash) {
			next_slash = Time.time + slash_delay;
			holdOn();
			hp -= slash_damage;
			Invoke ("setHurtFalse", 0.5f);
		}
	}
	
	void holdOn () {
		if (this.GetComponent<RotateScript>() != null)
			this.GetComponent<StartStopMoveScript>().stopRotateScript();
		if (this.GetComponent<MoveScript>() != null)
			this.GetComponent<StartStopMoveScript>().stopMoveScript();
	}
	
	void destroy() {
		if (this.GetComponent<Fulture_Attack> () != null)
			Instantiate (meat, meatSpawn.position, meatSpawn.rotation);
		Destroy (this.gameObject, 0.5f);
	}
}

