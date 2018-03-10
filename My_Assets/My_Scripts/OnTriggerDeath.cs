using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDeath : MonoBehaviour {

	public AudioSource source;

	GameObject manager;
	MySceneManager managerScript;

	void OnTriggerEnter (Collider collider) {
		if(collider.tag == "Player" || collider.tag == "hand") {
			// connect to manager script
			manager = GameObject.Find("Scene_Manager");
			managerScript = manager.GetComponent<MySceneManager>();
			source = manager.GetComponent<AudioSource>();

			// play sound
			source.PlayOneShot(managerScript.death, 1);

			// start gameover sequence
			if(managerScript.livesInt <= 0) {
				managerScript.gameOver = true;
			}
				
			// subtract life
			managerScript.livesInt -= 1;
			managerScript.livesText.text = "x " + managerScript.livesInt + "";

			// resurrect (moves the player back to start)
			managerScript.resurrect();

		}
	}
}
