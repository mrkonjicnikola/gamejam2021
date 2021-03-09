using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioDestroy : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        GameObject audioGameObject = GameObject.Find("GameBackgroundAudio");
        GameObject.Destroy(audioGameObject);
    }

    // Update is called once per frame
    void Update() {

    }
}
