using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public float moveForce = 0f;
    private Rigidbody rigidBody;
    public GameObject bullet;
    public GameObject bullet2;
    public Transform gun;
    public float shootRate = 0f;
    public float shootForce = 0f;
    private float shootRateTimeStamp;

    float h;
    float v;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        h = 0.1f;
        v = 0.0f;
        rigidBody.velocity = new Vector3(h, v, 0);

        Invoke("shootBullets", 3.0f);
    }

    // Update is called once per frame
    void Update() {

    }

    private void shootBullets() {
        GameObject gameObject;
        if(Random.Range(-10.0f, 10.0f) > 0.5f) {
            gameObject = (GameObject)Instantiate(bullet, gun.position, gun.rotation);
        } else {
            gameObject = (GameObject)Instantiate(bullet2, gun.position, gun.rotation);
        }

        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.x = 90;
        gameObject.transform.rotation = Quaternion.Euler(rotationVector);

        gameObject.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce);

        Invoke("shootBullets", 3.0f);

    }
}
