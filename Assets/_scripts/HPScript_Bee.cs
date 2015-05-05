using UnityEngine;
using System.Collections;

public class HPScript_Bee : MonoBehaviour {
		
		public float hp = 10;
		public float main_bullett_damage = 2;
		public float slash_damage = 5;
		public GameObject player;
		private float direction;
		Animator enemy_anim;
		private int i = 0;
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
				holdOn();
				destroy();
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
			if (col.CompareTag ("slash_area") && player.GetComponent<Animator>().GetBool("slash") && Time.time > next_slash) {
				next_slash = Time.time + slash_delay;
				holdOn();
				hp -= slash_damage;
				Invoke ("setHurtFalse", 0.5f);
			}
		}
		
		void holdOn () {
			direction = this.GetComponent<MoveScript> ().getDirection();
			this.GetComponent<MoveScript> ().setDirection(0);
		}
		
		void destroy() {
			Destroy (this.gameObject, 2f);
		}
	}
