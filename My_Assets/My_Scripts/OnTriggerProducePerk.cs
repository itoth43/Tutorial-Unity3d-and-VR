using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerProducePerk : MonoBehaviour {

	public AudioSource source;
	public GameObject coinPrefab;

	GameObject manager;
	MySceneManager managerScript;

	void OnTriggerEnter (Collider collider) {
		// connect to manager script
		manager = GameObject.Find("Scene_Manager");
		managerScript = manager.GetComponent<MySceneManager>();
		source = manager.GetComponent<AudioSource>();

		// play sound
		source.PlayOneShot(managerScript.boxHit, 1);

		// instantiate coin (rigidbody) with gravity
		Instantiate(coinPrefab);

		// destroy object when collided with
		Destroy (this.gameObject);
	}
}
