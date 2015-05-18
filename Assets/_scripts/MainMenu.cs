using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GameObject player;

	public void ChangeToScene (int sceneToChangeTo){
		if (sceneToChangeTo > 12) {
			Application.Quit ();
		} else { 
			if (Time.timeScale < 1)
				Time.timeScale = 1;
			Application.LoadLevel (sceneToChangeTo);
		}
	}



}
