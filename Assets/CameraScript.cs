using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject player;
	private Transform player_tr;
	private Vector3 player_pos;

	public float leftEnd = -80f;
	public float rightEnd = -50f;

	private Transform camera_tr;
	float height;

	// Use this for initialization
	void Start () {
		player_tr = player.GetComponent<Transform> ();
		player_pos = player_tr.position;
		height = player_pos.y;
		camera_tr = this.gameObject.GetComponent<Transform> ();

		player_pos = camera_tr.localPosition;

	}
	
	// Update is called once per frame
	void Update () {
		player_pos = player.GetComponent<Transform> ().position;
		camera_tr.localPosition = new Vector3 (player_pos.x, player_pos.y, -10f);

	}
}
