using UnityEngine;
using System.Collections;

public class HP_Script_Yeti : MonoBehaviour {

	public float starthp = 15;
	public float main_bullett_damage = 2;
	public float slash_damage = 5;
	public float angrySpeedmultiplier = 1.2f;
	public float slash_delay = 1.5f;
	public GameObject meat;
	public GameObject player;
	//public Transform meatSpawn;

	private float angrySpeed;
	private float direction;
	private Animator enemy_anim;
	private int i = 0;
	private int x = 0;
	private float next_slash = 0;
	private Animator player_anim;
	//public float currenthp;
	private bool angry = false;
	private float hp;
	
	// Use this for initialization
	void Start () {
		enemy_anim = this.GetComponent<Animator> ();
		player_anim = player.GetComponent<Animator> ();
		//currenthp = starthp;
		angrySpeed = this.GetComponent<Walk> ().getSpeed() * angrySpeedmultiplier;
		hp = starthp;
	}
	
	// Update is called once per frame
	void Update () {
		if (starthp < hp && angry == false) {
			this.GetComponent<Walk> ().setSpeed(angrySpeed);
			angry = true;
		}

		if (starthp < 1) {
			this.GetComponent<PolygonCollider2D>().enabled = false;
			enemy_anim.SetBool ("dead", true);
			//this.GetComponent<???>().enabled = false;
			holdOn();
			//Invoke ("giveMeat", 1f);
			destroy();
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("main_bullett")) {
			if (i == 0) {
				starthp -= main_bullett_damage;
				if (angry == false) {
					holdOn();
					Invoke ("setHurtFalse", 0.5f);
				}
				Invoke ("delay", 0.5f);
				i++;
			}
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("slash_area") && player_anim.GetBool("slash") && Time.time > next_slash) {
			next_slash = Time.time + slash_delay;
			holdOn();
			starthp -= slash_damage;
			Invoke ("setHurtFalse", 0.5f);
		}
	}
	
	void holdOn () {
		direction = this.GetComponent<Walk> ().getDirection();
		this.GetComponent<Walk> ().setDirection(0);
	}
	
	void destroy() {
		Destroy (this.gameObject, 2f);
	}

	void delay () {
		i = 0;
	}
	
	void giveMeat() {
		if (x == 0) {
			Instantiate (meat, this.GetComponent<Transform>().localPosition, this.GetComponent<Transform>().localRotation);
			x++;
		}
	}
	void setHurtFalse() {
		i = 0;
		this.GetComponent<Walk> ().direction.x = direction;
	}
}

