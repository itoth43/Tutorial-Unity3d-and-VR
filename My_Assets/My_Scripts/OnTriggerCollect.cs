using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerCollect : MonoBehaviour {

	public AudioSource source;
	public bool isCoin = false;

	GameObject manager;
	MySceneManager managerScript;

	void OnTriggerEnter (Collider collider) {
		if(collider.tag == "Player" || collider.tag == "hand") {
			// connect to manager script
			manager = GameObject.Find("Scene_Manager");
			managerScript = manager.GetComponent<MySceneManager>();
			source = manager.GetComponent<AudioSource>();

			// play sound
			source.PlayOneShot(managerScript.collectItem, 1);

			// when objects are coins are collected add to coin int, update coin text
			if (isCoin == true) {
				managerScript.coinsInt += 1;
				managerScript.coinsText.text = "x " + managerScript.coinsInt + "";
			}

			// destroy object when collided with
			Destroy (this.gameObject);
		}
	}
}
