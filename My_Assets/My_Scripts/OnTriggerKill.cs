using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerKill : MonoBehaviour {

	public AudioSource source;
	public GameObject coinPrefab;

	GameObject manager;
	MySceneManager managerScript;

	void OnTriggerEnter (Collider collider) {
		if(collider.tag == "hand") {
			// connect to manager script
			manager = GameObject.Find("Scene_Manager");
			managerScript = manager.GetComponent<MySceneManager>();
			source = manager.GetComponent<AudioSource>();

			// play sound
			source.PlayOneShot(managerScript.boxHit, 1);

			// instantiate coin (rigidbody) with gravity
			Instantiate(coinPrefab, new Vector3(this.transform.position.x, this.transform.position.y+5, this.transform.position.z + 7), Quaternion.identity);
			Instantiate(coinPrefab, new Vector3(this.transform.position.x, this.transform.position.y+5, this.transform.position.z - 7), Quaternion.identity);

			// destroy object when collided with
			Destroy (this.gameObject);
		}
	}
}
