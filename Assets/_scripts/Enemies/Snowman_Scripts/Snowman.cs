using UnityEngine;
using System.Collections;

public class Snowman : MonoBehaviour {

	public Transform snowballSpawn;
	public Transform player_pos;
	public GameObject snowball_throw;
	public GameObject snowball_straight;
	Animator anim;
	private bool canThrow = true;
	private float nextFire = 0.0f;
	public float fireRate = 5f;
	private bool throwing = true;

	// Use this for initialization
	void Start () {
		snowballSpawn = gameObject.GetComponent<Transform> ();

		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			anim.SetBool ("throw", true);
			if (throwing)
				Invoke ("doThrow", 0.5f);
			if (!throwing)
				Invoke ("doStraight", 0.5f);
		}
	}

	void doThrow() {
		Instantiate (snowball_throw, snowballSpawn.position, snowballSpawn.rotation);
		Invoke ("setThrowFalse", 0.3f);
		canThrow = false;
		throwing = false;
	}

	void doStraight() {
		Instantiate (snowball_straight, snowballSpawn.position, snowballSpawn.rotation);
		Invoke ("setThrowFalse", 0.3f);
		canThrow = false;
		throwing = true;
	}

	void setThrowFalse() {
		anim.SetBool ("throw", false);
	}
}
