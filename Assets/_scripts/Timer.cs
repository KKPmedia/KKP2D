using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float timer = 0.0f;
	public bool timerStarted = false;
	static Text instruction;

	float x = 0, y = 0, c = 0;
	static float a = 0;
	// Use this for initialization
	    	
	void Start() {
		instruction = this.GetComponent<Text> ();
	}

  	void Update(){
		if (timerStarted = true) {
			y += Time.timeScale;
			if (y >= 9) {
				y = 0;
				x++;
				if (x > 6) {
					c++;
					y = 0;
					x = 0;
				}
			}
			if (c >= 60) {
				c = 0; 
				a++;
			}
			instruction.text = a.ToString () + ":" + c.ToString () + ":" + x.ToString () + y.ToString ();
		}
	 }

	public static string getTime() {
		return instruction.ToString();
	}

	public static int getMin() {
		return System.Int32.Parse(a.ToString());
	}
}
