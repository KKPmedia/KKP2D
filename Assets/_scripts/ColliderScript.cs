using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {

	Animator anim;
	private bool dying = false;
	private Renderer meat_re;
	private Transform saurus_tr;
	private Transform meat_tr;
	private Vector3 meat_pos;

	public GameObject meat;

	public Vector2 gravity = new Vector2 (0, -100);
	public float jumpForce = 200f;

	public GameObject player;
	public float hurtForce;

	Rigidbody2D rb;
	Rigidbody2D player_rb;
	//Rigidbody2D meat_rb;
	Animator player_anim;
	MoveScript ms;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		player_rb = player.GetComponent<Rigidbody2D> ();
		player_anim = player.GetComponent<Animator> ();
		ms = this.GetComponent<MoveScript> ();

		meat_tr = meat.GetComponent<Transform> ();
		meat_re = meat.GetComponent<Renderer> ();
		meat_re.enabled = false;

		saurus_tr = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (dying) {
			anim.SetBool ("isDying", true);
		}
	}

	void FixedUpdate() {
		//meat_rb = meat.GetComponent<Rigidbody2D> ();
		rb = gameObject.GetComponent<Rigidbody2D> ();
		if (dying) {
			rb.AddForce (gravity);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Keule") && player_anim.GetBool ("inBeat")) {
			if (anim.GetBool ("hurt") == false) {
				anim.SetBool ("hurt", true);
				Invoke ("setHurtFalse", 0.5f);
			}
			dying = true;
		} else if (col.CompareTag ("Foot1")) {
			player_rb.AddForce (new Vector2 (0, jumpForce));
			player_anim.SetBool ("isGrounded", true);

			if (anim.GetBool ("hurt") == false) {
				anim.SetBool ("hurt", true);
				Invoke ("setHurtFalse", 0.5f);
		}
				dying = true;

		} else if (col.CompareTag ("Player") && dying == false) {
			player_anim.SetBool("inHurt" , true);
			player_rb.AddForce(new Vector2(hurtForce * (ms.speed.x * -1), 0));
			Invoke ("setInHurtFalse", 0.4f);
		}

		if (col.CompareTag ("Ground")) {
			this.gameObject.SetActive(false);
			meat_tr.position = new Vector3(saurus_tr.localPosition.x, saurus_tr.localPosition.y, saurus_tr.localPosition.z);
			meat_re.enabled = true;
		}
	}

	void setHurtFalse() {
		anim.SetBool ("hurt", false);
	}
	void setInHurtFalse() {
		player_anim.SetBool ("inHurt", false);
	}
}
