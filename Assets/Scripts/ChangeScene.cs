using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class ChangeScene : MonoBehaviour 
{
	void ChangeToScene(int sceneToChangeTo){
		Application.LoadLevel(sceneToChangeTo);
=======
public class ChangeScene : MonoBehaviour {

	
	// Update is called once per frame
	public void ChangeToScene (string toChangeTo) {
        Application.LoadLevel(toChangeTo);
>>>>>>> origin/master
	}
}
