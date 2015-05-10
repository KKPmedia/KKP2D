using UnityEngine;
using System.Collections;

public class Fulture_Attack : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(-2, 10);
	
	private Vector2 movement;
	private float timeCounter = 0;
	private MoveScript ms;
	
	void Start() {
		this.GetComponent<MoveScript> ();
	}

	// Use this for initialization
	void FixedUpdate() {
		GetComponent<Rigidbody2D>().velocity = movement;
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime;
		direction.y = Mathf.Cos (timeCounter);
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);	
	}
	
	void OnTriggerEnter2D (Collider2D col) {

	}
}

