﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float lifeTime;

    void Start() {
        Destroy(gameObject, lifeTime);
    }

    void Update() {

    }
}
