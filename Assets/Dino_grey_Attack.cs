using UnityEngine;
using System.Collections;

public class Dino_grey_Attack : MonoBehaviour {

	public Transform player;

	StartStopMoveScript ssms;
	Animator enemy_anim;
	Walk walk;
	private float thisY, stopPoint, walkSpeed, startPos;
	private bool saw = false, onStartPosition = true;

	// Use this for initialization
	void Start () {
		thisY = this.GetComponent<Transform> ().localPosition.y;	
		startPos = this.GetComponent<Transform> ().localPosition.x;
		enemy_anim = this.GetComponent<Animator> ();
		walk = this.GetComponent<Walk> ();
		stopPoint = walk.getDirection ();
		walkSpeed = walk.getSpeed ();
		ssms = this.GetComponent<StartStopMoveScript> ();
		ssms.stopWalkScript();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.localPosition.y >= thisY && !saw && onStartPosition) {
			saw = true;
			onStartPosition = false;
			ssms.startWalkScript();
			walk.setSpeed(walkSpeed);
			enemy_anim.SetBool ("walk", true);
		}

		if (walk.getDirection() != stopPoint && saw) {
			saw = false;
			walk.flip();
			walk.setSpeed(0);
			enemy_anim.SetBool("walk", false);
			Invoke ("walkBack", 2f);
		}

		if (this.GetComponent<Transform> ().localPosition.x <= startPos && onStartPosition == false && walk.getDirection() < stopPoint) {
			onStartPosition = true;
			walk.flip();
			walk.setSpeed(0);
			enemy_anim.SetBool("walk", false);
		}
	}

	void walkBack() {
		walk.flip();
		walk.setSpeed(walkSpeed / 2);
		enemy_anim.SetBool("walk", true);
	}
}
