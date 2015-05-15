using UnityEngine;
using System.Collections;

public class StartStopMoveScript : MonoBehaviour {

	public void stopMoveScript() {
		this.GetComponent<MoveScript> ().enabled = false;
	}
	public void startMoveScript() {
		this.GetComponent<MoveScript> ().enabled = true;
	}
	public void stopRotateScript() {
		this.GetComponent<RotateScript> ().enabled = false;
	}
	public void startRotateScript() {
		this.GetComponent<RotateScript> ().enabled = true;
	}
	public void stopWalkScript() {
		this.GetComponent<Walk> ().enabled = false;
	}
	public void startWalkScript() {
		this.GetComponent<Walk> ().enabled = true;
	}
	public void stopFollowScript() {
		this.GetComponent<Follow> ().enabled = false;
	}
	public void startFollowScript() {
		this.GetComponent<Follow> ().enabled = true;
	}
	public void stopWalkLeftScript() {
		this.GetComponent<WalkLeft>().enabled = false;
	}
	public void startWalkLeftScript() {
		this.GetComponent<WalkLeft> ().enabled = true;
	}
}
