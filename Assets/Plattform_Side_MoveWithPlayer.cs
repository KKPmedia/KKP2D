using UnityEngine;
using System.Collections;

public class Plattform_Side_MoveWithPlayer : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);
	public GameObject player;
	public Vector2 direction = new Vector2(1, 0);
	
	public float turnToRight = -5.3f;
	public float turnToLeft = 0f;
	
	private Vector2 movement, player_move;
	private float position_x;
	private bool player_on = false, x = true;


	void Start() {
		
	}
	// Use this for initialization
	void FixedUpdate() {

		GetComponent<Rigidbody2D>().velocity = movement;

		//if (player_on) {
			//player.GetComponent<Rigidbody2D>().AddForce(new Vector2 (direction.x * speed.x , 0));
			//player.localPosition = new Vector3 (this.GetComponent<Transform>().position.x, player.localPosition.y, player.localPosition.z);	

		}
	
	// Update is called once per frame
	void Update () {
		position_x = GetComponent<Transform> ().localPosition.x;

		if (position_x < turnToRight && direction.x < 0) {
			flip ();
		}
		if (position_x > turnToLeft && direction.x > 0) {
			flip ();
		}

	
		
		move();
	}

	void OnTriggerEnter2D(Collider2D col) {
		//if (col.CompareTag ("Player")) 
			//player_on = true;
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.CompareTag ("Player")) 
			player_on = true;
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.CompareTag ("Player")) 
			player_on = false;
	}
	
	void move () {
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
	}
	
	void flip () {
		direction.x = direction.x * -1;
	}
}

