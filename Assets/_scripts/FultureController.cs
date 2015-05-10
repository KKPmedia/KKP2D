using UnityEngine;
using System.Collections;

public class FultureController : MonoBehaviour {

	public Transform player;
	public float appear_position_x;

	private MoveScript ms;
	private Fulture_Attack atk;
	private float currenty;

	// Use this for initialization
	void Start () {
		ms = this.GetComponent<MoveScript> ();
		atk = this.GetComponent<Fulture_Attack> ();
		ms.enabled = false;
		atk.enabled = false;
		currenty = this.GetComponent<Transform> ().localPosition.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.localPosition.x > appear_position_x) {
			ms.enabled = true;
			Invoke ("attack", 2f);
		}
	}

	void attack () {
		ms.enabled = false;
		atk.enabled = true;

		//if (this.GetComponent<Transform> ().localPosition.y >= currenty) {
		//	ms.enabled = true;
		//	atk.enabled = false;
		//}
	}
}
