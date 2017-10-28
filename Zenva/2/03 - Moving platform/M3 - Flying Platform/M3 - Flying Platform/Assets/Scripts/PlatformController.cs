using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    // movement target
    public Transform target;

    // speed
    public float speed = 1;

    // flag that sets whether we are moving or not
    bool isMoving = false;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
        // Check for input
        HandleInput();

        // Move our platform
        HandleMovement();

    }

    void HandleInput()
    {
        //check for Fire1 axis
        if(Input.GetButtonDown("Fire1"))
        {
            // negate isMoving
            isMoving = !isMoving;
        }
    }

    // take care of movement
    void HandleMovement()
    {
        // if we are not moving, exit
        if (!isMoving) return;

        // calculate the distance from target
        float distance = Vector3.Distance(transform.position, target.position);

        // have we arrived?
        if (distance > 0)
        {

            // calculate how much we need to move (step) d = v * t
            float step = speed * Time.deltaTime;

            // move by that step
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
