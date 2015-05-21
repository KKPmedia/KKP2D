using UnityEngine;
using System.Collections;

public class WalkLeft : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);
	
	public Vector2 direction = new Vector2(1, 0);
	
	public float distance_x;
	
	private float turnToRight;
	//public float turnToLeft = -50f;
	private float turnToLeft;
	
	private Vector2 movement;
	private bool facingRight = true;
	private float position_x;
	
	// Use this for initialization
	void Start () {
		turnToLeft = this.GetComponent<Transform> ().position.x;
		turnToRight = turnToLeft - distance_x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().velocity = movement;
	}
	
	// Update is called once per frame
	void Update () {
		position_x = GetComponent<Transform> ().localPosition.x;
		
		if (this.transform.localScale.x > 0)
			facingRight = true;
		if (this.transform.localScale.x < 0) 
			facingRight = false;
		
		if (position_x < turnToRight && !facingRight) {
			flip ();
		}
		if (position_x > turnToLeft && facingRight) {
			flip ();
		}
		
		move();
	}
	
	void move () {
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (!col.CompareTag ("Player")) {
			//flip ();
		}
	}
	
	public void flip () {
		direction.x = direction.x * -1;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		
		transform.localScale = theScale;
	}
	
	public void setDirection(float x) {
		direction.x = x;
	}
	public float getDirection() {
		return direction.x;
	}
	public void setSpeed(float x) {
		speed.x = x;
	}
	public float getSpeed () {
		return speed.x;
	}
}



