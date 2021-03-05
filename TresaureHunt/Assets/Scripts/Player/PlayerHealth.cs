using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// The Player's health script including breathing mechanics
    /// </summary>
    /// 

    protected float airMax;
    protected float currentAmountOfAir;
    protected bool isDrowning;
    protected float timeLeftBeforePlayerHasDrowned;

    public float health;

    void Start()
    {
        airMax = 5;
        currentAmountOfAir = airMax;
        health = 3;
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
            LooseAir();
        }

        if(isDrowning == true)
        {
            Debug.Log("Time left before drowned: " + timeLeftBeforePlayerHasDrowned);
            if (timeLeftBeforePlayerHasDrowned > 0)
            {
                timeLeftBeforePlayerHasDrowned -=  Time.deltaTime;                
            }
            if (timeLeftBeforePlayerHasDrowned <= 0)
            {
                GameManager.ins.gameOver = true;
            }

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
        if(currentAmountOfAir > 0)
        {
            Debug.Log("Current Amount Of Air: " + currentAmountOfAir);
            currentAmountOfAir -= 0.5f * Time.deltaTime;
        }

    }

    //a method that is used when the player breathes. The method prevents the player from drowning
    public void Breathe() 
    {
        Debug.Log("took a breath");
        isDrowning = false;
        currentAmountOfAir = airMax;
    }

    //is used when the player has run out of air
    public void Drown()
    {
        isDrowning = true;

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
    public void Damage(int Damage) 
    {
        health -= Damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("AirBubble"))
        {
            Breathe();
        }
    }
}
