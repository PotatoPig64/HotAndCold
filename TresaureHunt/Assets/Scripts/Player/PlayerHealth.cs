using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Player
{
    /// <summary>
    /// The Player's health script
    /// </summary>
    void Start()
    {
        health = 3;
    }

   
    void Update()
    {
        //checks the health of the player
        Health();

        if(hasFallenIntoTheVoid == true)
        {
            health = 0;
        }
    }

    public override void Health()
    {
        if(health <= 0)
        {
            GameManager.ins.gameOver = true;
        }
    }

    //method for the player to take dmg
    public void Damage(int Damage) 
    {
        health -= Damage;
    }
}
