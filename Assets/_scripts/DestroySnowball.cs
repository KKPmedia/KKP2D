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
			Destroy (this.gameObject, 0f);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		//Destroy (gameObject, 0f);
	}
}
