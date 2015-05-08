using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {
	
	public float speed = 5f;
	public float height = 4f;
	public float width = 4f; 

	private float timeCounter = 0;
	private float x, y;
	private Vector2 pos;

	// Use this for initialization
	void Start () {
		pos = new Vector2 (this.GetComponent<Transform> ().localPosition.x, this.GetComponent<Transform> ().localPosition.y);
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime * speed;

		x = Mathf.Cos (timeCounter) * width + pos.x;
		y = Mathf.Sin (timeCounter) * height + pos.y;

		this.GetComponent<Transform> ().position = new Vector3 (x, y, this.GetComponent<Transform>().position.z);
	}
}
