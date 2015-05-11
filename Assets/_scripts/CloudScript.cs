using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour {

	public float start = 150f;
	public float end = -20;
	Transform tr;

	// Use this for initialization
	void Start () {
		tr = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tr.position.x < end) {
			tr.position = new Vector3 (start, tr.position.y, tr.position.z);
		}
	}
}
