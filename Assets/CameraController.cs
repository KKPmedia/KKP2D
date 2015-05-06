using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform player;
	public Vector2 marging, smoothing;
	public BoxCollider2D Bounds;
	private Vector3 min, max;

	public bool following;

	// Use this for initialization
	void Start () {
		min = Bounds.bounds.min;
		max = Bounds.bounds.max;
		following = true;
	}
	
	// Update is called once per frame
	void Update () {
		float x = this.GetComponent<Transform> ().position.x;
		float y = this.GetComponent<Transform> ().position.y;

		if (following) {
			if (Mathf.Abs(x - player.position.x) > marging.x)
				x = Mathf.Lerp (x, player.position.x, smoothing.x * Time.deltaTime);

			if (Mathf.Abs(y - player.position.y) > marging.y)
				y = Mathf.Lerp (y, player.position.y, smoothing.y * Time.deltaTime);
		}

		float cameraHalfWidth = this.GetComponent<Camera> ().orthographicSize * ((float)Screen.width / Screen.height);
		float orthographicSize = this.GetComponent<Camera>().orthographicSize;

		x = Mathf.Clamp (x, min.x + cameraHalfWidth, max.x - cameraHalfWidth);
		y = Mathf.Clamp (y, min.y + orthographicSize, max.y - orthographicSize);

		this.GetComponent<Transform> ().position = new Vector3 (x, y, -10f);
	}
}
