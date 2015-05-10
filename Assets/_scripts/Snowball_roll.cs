using UnityEngine;
using System.Collections;

public class Snowball_roll : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(-2, 10);
	public CircleCollider2D cc;
	public float grow = 0.1f;
	
	private Vector2 movement;
	private float timeCounter = 0;
	private bool throwing = true;
	private Transform size;
	
	void Start() {
		cc.enabled = false;
		size = this.GetComponent<Transform> ();
	}
	
	// Use this for initialization
	void FixedUpdate() {
		GetComponent<Rigidbody2D>().velocity = movement;
	}
	
	// Update is called once per frame
	void Update () {
		if (throwing) {
			timeCounter += Time.deltaTime;
			direction.y = Mathf.Cos (timeCounter * 3);
			movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);	
		}

		if (!throwing) {
			speed.y = 0;

			size.localScale = new Vector3 (size.localScale.x + Time.deltaTime * (grow / 4f), 
			                               size.localScale.y + Time.deltaTime * (grow / 4f), size.localScale.z);

			movement = new Vector2 (speed.x  * direction.x, speed.y * direction.y);	
		}	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("ground")) {
			this.GetComponent<DestroySnowball>().destroy(5);
			throwing = false;
			cc.enabled = true;
		}
	}
}
