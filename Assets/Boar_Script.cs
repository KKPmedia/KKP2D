using UnityEngine;
using System.Collections;

public class Boar_Script : MonoBehaviour {

	public float stopPoint;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (this.GetComponent<Transform>().localPosition.x > stopPoint)
		
	}
}
