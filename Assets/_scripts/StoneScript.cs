using UnityEngine;
using System.Collections;

public class StoneScript : MonoBehaviour {

	public float rotation = -2;
	public Vector2 width = new Vector2 (10, 10);
	public Vector2 direction = new Vector2 (0, 67);
	private Vector2 movement;
	private bool move;

	private bool right = true; 
	private bool rotate = true;

	public GameObject player;

	Animator player_anim;
	PlayerController pc;

	void Start () {
		player_anim = player.GetComponent<Animator> ();
		pc = player.GetComponent<PlayerController>();
	}

	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity = movement;
	}
	
	// Update is called once per frame
	void Update () {

		right = pc.isFacingRight();

		if (move) {
			movement = new Vector2 (width.x + direction.x, 
			                       width.y + direction.y);
		} else {
			movement = new Vector2 (0f, 0f);
		}

		if (rotate) {
			this.transform.Rotate (new Vector3(0, 0, transform.rotation.z + rotation));
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (!right && direction.x > 0) 
			flip ();
		else if (right && direction.x < 0)
			flip ();

		if (coll.CompareTag ("Ground"))
			rotate = false;
		if (coll.CompareTag ("Foot1") && player_anim.GetBool("inKick"))
			move = true;
	}

	void OnTriggerExit2D(Collider2D coll) {
		move = false;
		if (coll.CompareTag ("Ground"))
			rotate = true;
	}

	void flip() {
		direction.x = direction.x * -1;
		rotation = rotation * -1;
	}
}
