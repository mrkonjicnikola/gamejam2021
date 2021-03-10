using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
    public bool playerFinish;
    public bool shadowFinish;
    public bool fireCollision;
    public bool bulletCollision;

    GameObject audioGameObject;

    void Start() {
        playerFinish = false;
        shadowFinish = false;
        fireCollision = false;
        bulletCollision = false;

        audioGameObject = GameObject.Find("GameBackgroundAudio");
    }

    void Update() {
        if (playerFinish && shadowFinish) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //in case one bool is true and the other is not in the same frame that Update() is called
        if(playerFinish && !shadowFinish) {
            Invoke("checkShadow", 0.6f);
        }
        if (!playerFinish && shadowFinish) {
            Invoke("checkPlayer", 0.6f);
        }

        if (fireCollision) {
            reloadScene();
        }
        if (bulletCollision) {
            reloadScene();
        }


        //DEBUG
        if (Input.GetKeyDown(KeyCode.N)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            reloadScene();
        }
    }

    public void toggleShadowFinishBool() {
        shadowFinish = !shadowFinish;
        if (shadowFinish) Invoke("toggleShadowFinishBool", 1.2f);
    }

    public void togglePlayerFinishBool() {
        playerFinish = !playerFinish;
        if (playerFinish) Invoke("togglePlayerFinishBool", 1.2f);
    }

    private void checkShadow() {
        if (!shadowFinish) { // if not simultaneous finish
            reloadScene();
        }
    }

    private void checkPlayer() {
        if (!playerFinish) { // if not simultaneous finish
            reloadScene();
        }
    }

    private void reloadScene() {
        if(SceneManager.GetActiveScene().buildIndex == 4) GameObject.Destroy(audioGameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
