using UnityEngine;
using System.Collections;

public class CoinViewScript : MonoBehaviour {

	Renderer re;
	CoinScript go;
	Animator anim;

	
	// Use this for initialization
	void Start () {
		re = this.GetComponent<Renderer> ();
		go = this.GetComponent<CoinScript> ();
		anim = this.GetComponent<Animator> ();
		go.enabled = false;
		anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (re.isVisible) {
			go.enabled = true;
			anim.enabled = true;
		}
	}
}
