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
}
