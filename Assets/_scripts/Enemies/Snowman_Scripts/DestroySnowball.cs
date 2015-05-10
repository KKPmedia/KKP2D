using UnityEngine;
using System.Collections;

public class DestroySnowball : MonoBehaviour {

	public Snowman sm;
	Renderer re;

	// Use this for initialization
	void Start () {
		re = this.GetComponent<Renderer> ();
		sm = sm.GetComponent<Snowman> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (re.isVisible == false) {
			destroy (0);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			destroy(0.1f);
		}
	}

	public void destroy (float t) {
		Destroy (gameObject, t);
	}
}
