using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerHealthAndOxygenMechanics : MonoBehaviour
{
    /// <summary>
    /// The Player's health script including breathing mechanics
    /// </summary>
    /// 

    protected float airMax;
    public static float currentAmountOfAir;
    protected bool isDrowning;
    protected float timeLeftBeforePlayerHasDrowned;
    public static bool tookABreath;

    public static float health;

    void Start()
    {
        airMax = 10;
        currentAmountOfAir = airMax;
        health = 2;
    }

   
    void Update()
    {
        //checks the health of the player
        Health();

        //is used if the player falls into the void
        if (PlayerMainScript.hasFallenIntoTheVoid == true) 
        {
            health = 0;
        }

        //is used when the player runns out of air
        if (currentAmountOfAir <= 0) 
        {
            if(isDrowning == false)
            {
                Drown();
            }
        }

        if (PlayerMainScript.isUnderWater == true)
        {
            //calls the funktion that makes t the player is loosing air while under water
            LooseAir();

            //this is used in conection with the HUD so that the bubbles refils when the player breathes again
            if(tookABreath == true && currentAmountOfAir < 10)
            {
                tookABreath = false;
            }
        }

        //is used when the player is drowning
        if(isDrowning == true)
        {
            //the player has, depending on how many lifes they still have, a sertain amount of time to find an airbubble to breathe after they're out of air.
            if (timeLeftBeforePlayerHasDrowned > 0)
            {
                timeLeftBeforePlayerHasDrowned -=  Time.deltaTime;                
            }
            if (timeLeftBeforePlayerHasDrowned <= 0)
            {
                GameManager.ins.gameOver = true;
            }

            //these three ifstatements reduces the players health while they're drowning
            if(timeLeftBeforePlayerHasDrowned < 2.5f && timeLeftBeforePlayerHasDrowned > 1.5f)
            {
                health = 2;
            }
            if (timeLeftBeforePlayerHasDrowned < 1.5f && timeLeftBeforePlayerHasDrowned > 0.5f)
            {
                health = 1;
            }
            if(timeLeftBeforePlayerHasDrowned <= 0)
            {
                health = 0;
            }
        }
    }

    //a method that checks the player's health and ends the game if the player is out of lives
    public  void Health() 
    {
        if(health <= 0)
        {
            GameManager.ins.gameOver = true;
        }
    }

    //a method that reduces the players currentAmountOfAir. 
    public void LooseAir() 
    {
        //makes the player loos air if the player has any air left
        if(currentAmountOfAir > 0)
        {
            currentAmountOfAir -=  Time.deltaTime;
        }

    }

    //a method that is used when the player breathes. It's the method prevents the player from drowning
    public void Breathe() 
    {
        tookABreath = true;
        isDrowning = false;
        currentAmountOfAir = airMax;
    }

    //is used when the player has run out of air
    public void Drown()
    {
        isDrowning = true;

        //gives the player different amounts of time they have before they drown depending on how many lifes they have left when they ran out of air
        switch (health)
        {
            case 1:
                timeLeftBeforePlayerHasDrowned = 1;
                break;
            case 2:
                timeLeftBeforePlayerHasDrowned = 2;
                break;
            case 3:
                timeLeftBeforePlayerHasDrowned = 3;
                break;
            default:
                timeLeftBeforePlayerHasDrowned = 1;
                break;
        }

        timeLeftBeforePlayerHasDrowned -= Time.deltaTime;
        return;
    }

    //method for the player to take dmg 
    //is used together with the enemies scripts 
    public void Damage(int Damage) 
    {
        health -= Damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //cheks if the collision the player had was with an air bubble, and if it was the player will breathe
        if (collision.gameObject.tag.Equals("AirBubble"))
        {
            Breathe();
        }
    }
}
