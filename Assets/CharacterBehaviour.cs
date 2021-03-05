using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour {

    //Rigidbody rigidBody;
    
    public float speed = 2.0f;
    
    public Vector3 movement;

    Vector3 up = Vector3.zero;
    Vector3 right = new Vector3(0, 90, 0);
    Vector3 down = new Vector3(0, 180, 0);
    Vector3 left = new Vector3(0, 270, 0);

    Vector3 currentDirection = Vector3.zero;
    Vector3 nextPosition, destination, direction;

    bool canMove;
    float rayLength = 1f;


    void Start() {
        //rigidBody = GetComponent<Rigidbody>();
        //isMoving = false;

        currentDirection = up;
        nextPosition = Vector3.forward;
        destination = transform.position;
        canMove = false;
    }

    void Update() {
        ProcessInput();
    }

    private void ProcessInput() {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            nextPosition = Vector3.forward;
            currentDirection = up;
            canMove = true;
        } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            nextPosition = Vector3.back;
            currentDirection = down;
            canMove = true;
        } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            nextPosition = Vector3.left;
            currentDirection = left;
            canMove = true;
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            nextPosition = Vector3.right;
            currentDirection = right;
            canMove = true;
        } else if (Input.GetKeyDown(KeyCode.M)) {
            print("p: " + transform.position);
            print("d: " + destination);
            print("np: " + nextPosition);
        }

        if (Vector3.Distance(destination, transform.position) <= 0.00001f) {
            transform.localEulerAngles = currentDirection;
            if (canMove) {
                if (ValidNextStep()) {
                    destination = transform.position + nextPosition;
                    direction = nextPosition;
                    canMove = false;
                } 
            }
            
        }

    }

    bool ValidNextStep() {
        Ray myRay = new Ray(transform.position + new Vector3(0, 0.25f, 0), transform.forward);
        RaycastHit hit;

        Debug.DrawRay(myRay.origin, myRay.direction, Color.red);

        if (Physics.Raycast(myRay, out hit, rayLength)){
            if(hit.collider.tag == "Obstacle") {
                return false;
            }
        }
        return true;
    }
}
