using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {
	
	public Vector2 speed = new Vector2(10, 10);
	
	public Vector2 direction = new Vector2(2, 0);
	
	private Vector2 movement;
	
	public GameObject player;
	private PlayerController pc;
	
	private bool right = true;
	
	void Start() {
		pc = player.GetComponent<PlayerController> ();
		right = pc.isFacingRight();
	}
	
	// Use this for initialization
	void FixedUpdate() {
		GetComponent<Rigidbody2D>().velocity = movement;
	}
	
	// Update is called once per frame
	void Update () {

		if (right && direction.x < 0)
			flip ();
		else if (!right && direction.x > 0)
			flip ();
		
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);	
	}
	
	void flip () {
		direction.x = direction.x * -1;
	}
}
