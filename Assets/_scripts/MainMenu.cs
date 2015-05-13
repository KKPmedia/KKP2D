using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{

	public void ChangeToScene (int sceneToChangeTo){
		if (sceneToChangeTo > 12) {
			Application.Quit();
		}
		else
		Application.LoadLevel (sceneToChangeTo);
	}



}
