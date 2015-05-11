using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public void ChangeToScene (int sceneToChangeTo){
		Application.LoadLevel (sceneToChangeTo);
	}


}
