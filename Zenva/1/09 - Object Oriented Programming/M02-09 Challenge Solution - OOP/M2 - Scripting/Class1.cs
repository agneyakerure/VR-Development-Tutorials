using System;

public class Character
{
    public string name;
    public float energy = 100;
    public int coins;
}
    //method to get score
    public int GetScore(int baseScore, int coinScore)
    {
        //the character gets "coinScore" points per 
        //coin collected, plus a base of "baseScore"
        int score = baseScore + coins * coinScore;
        return score;
    }
}



    //private member variable
    //can't be accessed from outside the class
    private bool isAlive;

    //by default, member variables are private:
    int score;
}
    void start()
    {
        //create an instance of "Character"
        Character hero = new Character();

        //access public variables
        hero.name = "Mr White";
        hero.energy = 10;
        hero.coins = 10;

        //get score
        int playerScore = hero.GetScore(100, 5);

        //show it in the console
        print(playerScore);



        //print the hero's name
        hero.PrintName();


        Character secondHero = new Character();

        Character enemy = new Character();
    }
}

