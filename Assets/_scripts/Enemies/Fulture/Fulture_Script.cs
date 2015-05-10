using UnityEngine;
using System.Collections;

public class Fulture_Script : MonoBehaviour {


	public Transform meatSpawn;
	public GameObject meat;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Meat")) {
			this.GetComponent<MoveScript>().direction.y = 1f;
			Instantiate (meat, meatSpawn.position, meatSpawn.rotation);
		}
	}
}
