using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MySceneManager : MonoBehaviour {

	// Score board elements
	public Text coinsText;
	public int coinsInt = 0;

	public Text livesText;
	public int livesInt = 5;

	// Timer
	public Text timeText;
	private float updateTime = 0.0f;

	// Audio
	public AudioClip death;
	public AudioClip collectItem;
	public AudioClip boxHit;
	public AudioClip complete;

	private AudioSource source;

	// Scene Event Variables
	public bool gameOver = false;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}

	// resurrect (moves the player back to start)
	public void resurrect() {
		Debug.Log("resurrect Player");
		GameObject vrtk_manFind = GameObject.Find("[CameraRig]");
		//		GameObject vrtk_scriptsFind = GameObject.Find("VRSimulatorCameraRig");
		vrtk_manFind.transform.position = new Vector3 (0, 0, 0);
		//		vrtk_scriptsFind.transform.position = new Vector3 (0, 0, 0);
	}
}
