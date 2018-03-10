using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFade : MonoBehaviour {

    private const float defaultFadeTime = 1f;

    public static Object screenFadePrefab;
    private static AsyncOperation loadOperation;

    public static void Initialize() {
        if(screenFadePrefab == null) {
			screenFadePrefab = Resources.Load("ScreenFadePrefab");
        }
    }

    public static void Fade(float timePerFade = defaultFadeTime) {
        if(screenFadePrefab == null) {
            Initialize();
        }

        GameObject screenFadeObject = (GameObject) Object.Instantiate(screenFadePrefab);
        ScreenFade screenFade = screenFadeObject.GetComponent<ScreenFade>();

        screenFade.timePerFade = timePerFade;

        DontDestroyOnLoad(screenFadeObject);
    }

	public static void StartSceneTransition(string sceneName, float timePerFade = defaultFadeTime) {
        if(CanLoadScene() != true) {
            // Prevent double loads

            return;
        }

        loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        loadOperation.allowSceneActivation = false;

        Fade(timePerFade);
    }

    private static bool CanLoadScene() {
        return (loadOperation == null || loadOperation.isDone == true);
    }





    public float time;
    public static FadeMode fadeMode;
    public float timePerFade;
    public Material fadeMaterial;

    public enum FadeMode {
        onlyFadeStart,
        FadeStart,
        FadeEnd,
        Wait,
        Done,
    }

    public static void onlyFadeStart () {
        fadeMode = FadeMode.onlyFadeStart;
    }

    private void Awake() {
        time = 0;
        fadeMode = FadeMode.FadeStart;
        timePerFade = defaultFadeTime;
        fadeMaterial = this.gameObject.GetComponentInChildren<MeshRenderer>().materials[0];

        LockToCamera();
        HandleFade(0);
    }

    private void LockToCamera() {

        // Attach to be in front of the camera
        GameObject parentObject = Camera.main.gameObject;
        this.gameObject.transform.position = parentObject.transform.position;
        this.gameObject.transform.rotation = parentObject.transform.rotation;
    }

    private void Start() {

    }

    private void Update() {
        LockToCamera();

        switch(fadeMode) {
            default:
                break;

            case FadeMode.onlyFadeStart:
                time += Time.deltaTime;

                if(time >= timePerFade) {
                    time = timePerFade;

                    fadeMode = FadeMode.Done;
                }

                break;
            case FadeMode.FadeStart:
                time += Time.deltaTime;

                if(time >= timePerFade) {
                    time = timePerFade;

                    fadeMode = FadeMode.Wait;
                }

                break;
            case FadeMode.FadeEnd:
                time -= Time.deltaTime;

                if(time <= 0) {
                    fadeMode = FadeMode.Done;  // Will destroy next frame
                }
                break;
            case FadeMode.Wait:
                //Debug.Log(loadOperation.allowSceneActivation + " " + loadOperation.isDone + " " + loadOperation.progress);
                if(loadOperation != null) {
                    if(loadOperation.isDone == true || loadOperation.progress >= 0.9f) {
                        loadOperation.allowSceneActivation = true;

                        fadeMode = FadeMode.FadeEnd;
                    } else {
                        // continue waiting
                    }
                } else {
                    fadeMode = FadeMode.FadeEnd;  // no point waiting if there's nothing to load
                }
                break;
            case FadeMode.Done:
                Destroy(this.gameObject);
                break;
        }

        float fadeFactor = time / timePerFade;
        HandleFade(fadeFactor);
    }

    private void HandleFade(float fadeFactor) {
        Color color = fadeMaterial.color;
        color.a = fadeFactor;
        fadeMaterial.color = color;
    }

}
