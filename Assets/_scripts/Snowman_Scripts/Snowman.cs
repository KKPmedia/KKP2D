using UnityEngine;
using System.Collections;

public class Snowman : MonoBehaviour {

	public Transform snowballSpawn;
	public Transform player_pos;
	public GameObject snowball;
	Animator anim;
	private bool canThrow = true;
	private float nextFire = 0.0f;
	public float fireRate = 5f;

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
			Invoke ("doThrow", 0.5f);
		}
	}

	void doThrow() {
		Instantiate (snowball, snowballSpawn.position, snowballSpawn.rotation);
		Invoke ("setThrowFalse", 0.3f);
		canThrow = false;
	}

	void setThrowFalse() {
		anim.SetBool ("throw", false);
	}
}
