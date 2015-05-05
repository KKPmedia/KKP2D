using UnityEngine;
using System.Collections;

public class SortingLayerScript : MonoBehaviour {

	private PlayerController pc;
	//private int layer;

	public GameObject keule;
	public GameObject hand1;
	public GameObject hand2;

	private bool right = true;

	SpriteRenderer com;

	// Use this for initialization
	void Start () {
		pc = this.GetComponent<PlayerController> ();

		keule = keule.GetComponent<GameObject> ();
		hand1 = hand1.GetComponent<GameObject> ();
		hand2 = hand2.GetComponent<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		right = pc.isFacingRight();
		if (right) {
			hand1.AddComponent(keule.GetType());
		} else {
			hand2.AddComponent(keule.GetType());
		}
	}
}
