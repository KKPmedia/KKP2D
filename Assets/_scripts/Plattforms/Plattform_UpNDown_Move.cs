using UnityEngine;
using System.Collections;

public class Plattform_UpNDown_Move : MonoBehaviour {
	
	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(0, 1);
	public float turnToDown = 11f;
	
	private Vector2 movement;
	private float position_y;
	private float turnToUp;
	private bool moveUp;
	
	void Start() {
		turnToUp = GetComponent<Transform> ().localPosition.y;
	}
	// Use this for initialization
	void FixedUpdate() {
		GetComponent<Rigidbody2D>().velocity = movement;
	}
	
	// Update is called once per frame
	void Update () {
		position_y = GetComponent<Transform> ().localPosition.y;

		if (direction.y < 0)
			moveUp = false;
		if (direction.y > 0)
			moveUp = true;
		
		if (position_y > turnToDown && moveUp) {
			flip ();
		}
		if (position_y < turnToUp && !moveUp) {
			flip ();
		}
		
		move();
	}
	
	void move () {
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
	}
	
	void flip () {
		direction.y = direction.y * -1;		
	}
}
