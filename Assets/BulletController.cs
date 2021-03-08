using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject blueBullet;

    void Start() {
        Instantiate(blueBullet, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
