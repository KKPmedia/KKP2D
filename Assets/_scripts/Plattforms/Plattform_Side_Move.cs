using UnityEngine;
using System.Collections;

public class Plattform_Side_Move : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);
	
	public Vector2 direction = new Vector2(1, 0);

	public float turnToRight = -5.3f;
	public float turnToLeft = 0f;
	
	private Vector2 movement;
	private float position_x;

	void Start() {
	
	}
	// Use this for initialization
	void FixedUpdate() {
		GetComponent<Rigidbody2D>().velocity = movement;
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

	void move () {
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
	}

	void flip () {
		direction.x = direction.x * -1;
	}
}

