using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour {

    // public variable
    public string myGameIdea;

	// Use this for initialization
	void Start () {
        //execute
        PrintGame();
	}

    // create method
    void PrintGame()
    {
        // print message to the user
        Debug.Log(myGameIdea);
    }
}

