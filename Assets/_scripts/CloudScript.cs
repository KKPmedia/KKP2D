using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour {

	private float start;
	public float end = -60;
	Transform tr;

	// Use this for initialization
	void Start () {
		tr = this.GetComponent<Transform> ();
		start = tr.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (tr.position.x < end) {
			tr.position = new Vector3 (start, tr.position.y, tr.position.z);
		}
	}
}
