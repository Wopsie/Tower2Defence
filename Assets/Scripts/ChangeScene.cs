using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour 
{
	void ChangeToScene(int sceneToChangeTo){
		Application.LoadLevel(sceneToChangeTo);
	}
}
