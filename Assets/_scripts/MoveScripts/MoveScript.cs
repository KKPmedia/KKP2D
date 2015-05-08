using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	
	public Vector2 speed = new Vector2(10, 10);
	
	public Vector2 direction = new Vector2(2, 0);
	
	private Vector2 movement;

	void Start() {
	
	}

	// Use this for initialization
	void FixedUpdate() {
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	// Update is called once per frame
	void Update () {
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);	
	}

	public float getDirection() {
		return direction.x;
	}

	public void setDirection(float x) {
		direction.x = x;
	}
}
