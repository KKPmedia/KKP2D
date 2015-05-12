﻿using UnityEngine;
using System.Collections;

public class Plant_HPScript : MonoBehaviour {

	public float hp = 10;
	public float main_bullett_damage = 2;
	public float slash_damage = 5;
	public GameObject main_bullett;
	//public GameObject meat;
	public GameObject player;
	private float direction;
	DestroyShoot main_bullett_destroy;
	Animator enemy_anim;
	private int i = 0;
	private int x = 0;
	private float next_slash = 0;
	public float slash_delay = 1.5f;
	
	// Use this for initialization
	void Start () {
		enemy_anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (hp < 1) {
			enemy_anim.SetBool ("dead", true);
			//this.GetComponent<AttackScript>().enabled = false;
			//holdOn();
			//Invoke ("giveMeat", 0.6f);
			destroy();
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("main_bullett")) {
			if (i == 0) {
				//holdOn();
				//enemy_anim.SetBool("hurt", true);
				hp -= main_bullett_damage;
				Invoke ("setHurtFalse", 0.5f);
				i++;
			}
		}

		if (col.CompareTag ("slash_area") && player.GetComponent<Animator>().GetBool("slash") && Time.time > next_slash) {
			next_slash = Time.time + slash_delay;
			//holdOn();
			//enemy_anim.SetBool("hurt", true);
			hp -= slash_damage;
			//Invoke ("setHurtFalse", 0.5f);
		}
	}
	
	void destroy() {
		Destroy (this.gameObject, 2f);
	}

	void setHurtFalse() {
		i = 0;
	}
}