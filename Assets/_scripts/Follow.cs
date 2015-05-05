using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	
	public Vector2 speed = new Vector2(10, 10);
	
	public Vector2 direction = new Vector2(2, 0);
	
	private Vector2 movement;
	
	public GameObject player;

	public float verzoegerung = 0.5f;
	private float player_x;
	private float dino_x;
	private bool delay = false;
	
	void Start() {

	}
	
	// Update is called once per frame
	void Update () {
		if (!delay) {
			player_x = player.GetComponent<Transform> ().position.x;
			dino_x = this.GetComponent<Transform> ().position.x;

			if (dino_x < player_x && direction.x < 0) {
				delay = true;
				Invoke ("flip", verzoegerung);
			}
			if (dino_x > player_x && direction.x > 0) {
				delay = true;
				Invoke ("flip", verzoegerung);
			}
		
			movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);	
		}
	}

	// Use this for initialization
	void FixedUpdate() {
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	public float getDirection () {
		return direction.x;
	}
	public void setDirection (float x) {
		this.direction.x = x;
	}

	void flip () {
		direction.x = direction.x * -1;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;

		delay = false;
		
		transform.localScale = theScale;
	}
}
