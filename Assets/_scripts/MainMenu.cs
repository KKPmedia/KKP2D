using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GameObject nomuted;
	public void ChangeToScene (int sceneToChangeTo){
		if (sceneToChangeTo == 13) {
			Application.Quit ();
		} else { 
			if (Time.timeScale < 1)
				Time.timeScale = 1;
			Application.LoadLevel (sceneToChangeTo);
		}
	
		if (sceneToChangeTo == 99) {
			AudioListener.volume = 0;
			nomuted.SetActive (false);
		}
		if (sceneToChangeTo == 100) {
			AudioListener.volume = 1;
			nomuted.SetActive (true);
		}
	}

	void Start(){
		if (AudioListener.volume == 1) {
			nomuted.SetActive (true);
		} else {
			nomuted.SetActive (false);
		}


	}




}
