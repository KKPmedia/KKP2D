﻿using UnityEngine;
using System.Collections;

public class HP_Script_Kong : MonoBehaviour {
		
		public float hp = 10;
		public float main_bullett_damage = 2;
		public float slash_damage = 5;
		public float angrySpeed = 7;

		public GameObject main_bullett;
		public GameObject meat;
		public GameObject player;
		private float direction;
		DestroyShoot main_bullett_destroy;
		Animator enemy_anim;
		private int i = 0;
		private int x = 0;
		private float next_slash = 0;
		public float slash_delay = 1.5f;
		private Animator player_anim;
		
		// Use this for initialization
		void Start () {
			enemy_anim = this.GetComponent<Animator> ();
			player_anim = player.GetComponent<Animator> ();
		}
		
		// Update is called once per frame
		void Update () {
			if (hp < 10) {
				this.GetComponent<Walk> ().setSpeed(angrySpeed);
		}
			if (hp < 1) {
				enemy_anim.SetBool ("dead", true);
				this.GetComponent<Attack_Script_Kong>().enabled = false;
				holdOn();
				Invoke ("giveMeat", 0.6f);
				destroy();
			}
		}
		
		void OnTriggerEnter2D (Collider2D col) {
			if (col.CompareTag ("main_bullett")) {
				if (i == 0) {
					holdOn();
					enemy_anim.SetBool("hurt", true);
					hp -= main_bullett_damage;
					Invoke ("setHurtFalse", 0.5f);
					i++;
				}
			}
			if (col.CompareTag ("slash_area") && player_anim.GetBool("slash") && Time.time > next_slash) {
				next_slash = Time.time + slash_delay;
				holdOn();
				enemy_anim.SetBool("hurt", true);
				hp -= slash_damage;
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
		
		void giveMeat() {
			if (x == 0) {
				Instantiate (meat, transform.position, transform.rotation);
				x++;
			}
		}
		void setHurtFalse() {
			i = 0;
			enemy_anim.SetBool ("hurt", false);
			this.GetComponent<Walk> ().direction.x = direction;
		}
	}
