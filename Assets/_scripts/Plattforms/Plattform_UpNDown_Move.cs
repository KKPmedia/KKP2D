using UnityEngine;
using System.Collections;

public class Plattform_UpNDown_Move : MonoBehaviour {
	
	public Vector2 speed = new Vector2(10, 10);
	
	public Vector2 direction = new Vector2(0, 1);
	
	public float turnToUp = 5f;
	public float turnToDown = 11f;
	
	private Vector2 movement;
	private bool right = true;
	private float position_y;
	
	void Start() {
		
	}
	// Use this for initialization
	void FixedUpdate() {
		GetComponent<Rigidbody2D>().velocity = movement;
	}
	
	// Update is called once per frame
	void Update () {
		position_y = GetComponent<Transform> ().localPosition.y;
		
		if (position_y > turnToDown) {
			flip ();
		}
		if (position_y < turnToUp) {
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
