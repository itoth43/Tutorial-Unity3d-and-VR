using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerCelebrate : MonoBehaviour {

	public AudioSource source;
	public GameObject fwPrefab;
	public GameObject flag;

	GameObject manager;
	MySceneManager managerScript;

	void OnTriggerEnter (Collider collider) {
		if(collider.tag == "Player") {
			// connect to manager script
			manager = GameObject.Find("Scene_Manager");
			managerScript = manager.GetComponent<MySceneManager>();
			source = manager.GetComponent<AudioSource>();

			// play sound
			source.PlayOneShot(managerScript.collectItem, 1);

			// raise flag
			flag.transform.position += Vector3.up * 5.0F;
			// create fireworks prefab
			Instantiate(fwPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, 1));
			Instantiate(fwPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, 1));

			Destroy (this.gameObject);
		}
	}
}
