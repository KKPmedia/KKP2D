using UnityEngine;
using System.Collections;

public class MeatScript : MonoBehaviour {

	public GameObject player;
	public float Hp = 1f;

	private PlayerController hp_player;

	// Use this for initialization
	void Start () {
		hp_player = player.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			hp_player.setHP(hp_player.getHP() + Hp); 
		}
	}
}
