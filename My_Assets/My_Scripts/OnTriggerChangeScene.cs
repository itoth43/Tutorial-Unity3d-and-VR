using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerChangeScene : MonoBehaviour {

	public string sceneName;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("Changing Scene...");
			ScreenFade.StartSceneTransition(sceneName);
			//			SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
		}
	}
}