using UnityEngine;
using System.Collections;

public class CameraViewScript : MonoBehaviour {

	Renderer re;
	MoveScript ms;

	// Use this for initialization
	void Start () {
		re = this.GetComponent<Renderer> ();
		ms = this.GetComponent<MoveScript> ();
		ms.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (re.isVisible)
			ms.enabled = true;
	}
}
