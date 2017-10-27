using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //walking spead
    public float walkSpeed;

    //jumping speed
    public float jumpSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Input on x (Horizontal)
        float hAxis = Input.GetAxis("Horizontal");
                
        // Input on z (Vertical)
        float vAxis = Input.GetAxis("Vertical");

        // Movement vector
        Vector3 movement = new Vector3(hAxis * walkSpeed * Time.deltaTime, 0, vAxis * walkSpeed * Time.deltaTime);

        // Calculate the new position
        Vector3 newPos = transform.position + movement;
    }
}
