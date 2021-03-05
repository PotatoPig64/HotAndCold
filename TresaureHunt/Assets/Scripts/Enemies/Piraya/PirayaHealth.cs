using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirayaHealth : superklassEntity
{

    void Start()
    {
        health = 2;
    }

    void Update()
    {
        Health();
    }

    public override void Health()
    {
        if(health <= 0)
        {
            //kills the gameobject when it dies
            Destroy(gameObject);
        }
    }

    //makes the enemy's health go down if it's hit by the player 
    public void Damage(int Damage)  
    { 
        health -= Damage;
    }
}
