using UnityEngine;
using System.Collections;

public class dino_red : MonoBehaviour {
	
	Renderer re;
	Follow script;
	AttackScript ats;


	// Use this for initialization
	void Start () {
		re = this.GetComponent<Renderer> ();
		ats = this.GetComponent<AttackScript> ();
		script = this.GetComponent<Follow> ();
		script.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (re.isVisible && !ats.isAttack ())
			script.enabled = true;
		else 
			script.enabled = false;
	}
}