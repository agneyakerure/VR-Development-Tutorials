using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //variable declaration
        string playerName;
        
        //variable assignment
        playerName = "Mr Pink";

        //show that to the user
        print(playerName);

        //variable declaration + assignment
        string enemyName = "Miss Orange";

        //show that
        print(enemyName);

        //energy
        float energy = 1.5f;

        // number of lives
        int n = 10;

        // is alive?
        bool isAlive = true;

        // total score of a user
        int levelsCompleted = 10;
        int totalScore = levelsCompleted * 10;

        float total = 100 + 1.5f;

        int lives = 5 - 1;

        float parts = 100 / 50;

        float combination = (100 + 1.5f) * 10 / 100;

        print(combination);

        print("The result for " + playerName + " is: " + combination);

        // declare variable (C)
        float c = 20;
        float f;

        // perform calculation
        f = c * 9 / 5 + 32;

        // show to the user
        print("the result is: " + f);
	}
}

