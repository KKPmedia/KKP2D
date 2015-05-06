using UnityEngine;
using System.Collections;

public class snowman_camera_view : MonoBehaviour {
		
		Renderer re;
		Snowman ms;
		
		// Use this for initialization
		void Start () {
			re = this.GetComponent<Renderer> ();
			ms = this.GetComponent<Snowman> ();
			ms.enabled = false;
		}
		
		// Update is called once per frame
		void Update () {
			if (re.isVisible)
				ms.enabled = true;
		}
	}
