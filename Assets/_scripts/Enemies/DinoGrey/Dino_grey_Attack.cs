using UnityEngine;
using System.Collections;

public class Dino_grey_Attack : MonoBehaviour {

	public Transform player;

	StartStopMoveScript ssms;
	Animator enemy_anim;
	Walk walk;
	WalkLeft walkL;
	private float thisY, stopPoint, walkSpeed, startPos;
	private bool saw = false, onStartPosition = true;

	// Use this for initialization
	void Start () {
		thisY = this.GetComponent<Transform> ().localPosition.y;	
		startPos = this.GetComponent<Transform> ().localPosition.x;
		enemy_anim = this.GetComponent<Animator> ();
		if (this.GetComponent<Walk> () != null) {
			walk = this.GetComponent<Walk> ();
		} else if (this.GetComponent <WalkLeft> () != null) {
			walkL = this.GetComponent<WalkLeft>();
		}
		stopPoint = walkL.getDirection ();
		walkSpeed = walkL.getSpeed ();
		ssms = this.GetComponent<StartStopMoveScript> ();
		ssms.stopWalkLeftScript();
	}
	
	// Update is called once per frame
	void Update () {
		if (!saw && onStartPosition && player.localPosition.y <= (thisY + 1) && player.localPosition.y >= (thisY - 1)) {
			saw = true;
			onStartPosition = false;
			ssms.startWalkLeftScript();
			walkL.setSpeed(walkSpeed);
			enemy_anim.SetBool ("walk", true);
		}

		if (walkL.getDirection() != stopPoint && saw) {
			saw = false;
			walkL.flip();
			walkL.setSpeed(0);
			enemy_anim.SetBool("walk", false);
			Invoke ("walkBack", 2f);
		}

		if (this.GetComponent<Transform> ().localPosition.x >= startPos && onStartPosition == false && walkL.getDirection() > stopPoint) {
			onStartPosition = true;
			walkL.flip();
			walkL.setSpeed(0);
			enemy_anim.SetBool("walk", false);
		}
	}

	void walkBack() {
		walkL.flip();
		walkL.setSpeed(walkSpeed / 2);
		enemy_anim.SetBool("walk", true);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("attack_area")) {
			enemy_anim.SetBool ("attack", true);
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.CompareTag ("attack_area")) {
			enemy_anim.SetBool ("attack", false);
		} 
	}
}
