using UnityEngine;
using System.Collections;

public class DestroyShoot : MonoBehaviour {

	Renderer re;

	// Use this for initialization
	void Start () {
		re = this.GetComponent<Renderer> ();
	}
	// Update is called once per frame
	void Update () {
		if (re.isVisible == false) 
			Destroy (gameObject, 0f);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("enemy") || col.CompareTag ("penguin"))
			Destroy (gameObject, 0.1f);
		if (col.CompareTag ("ground")) {
			Destroy (gameObject, 0f);
		}
	}
}
