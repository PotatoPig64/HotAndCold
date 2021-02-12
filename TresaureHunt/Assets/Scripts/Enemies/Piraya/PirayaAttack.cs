using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirayaAttack : superklassEntity
{
    public bool isAttacking;
    public Collider2D AttackTrigger;

    void Start()
    {
        //makes sure the attack collider is not enabled when the enemy spawns
        AttackTrigger.enabled = false;
    }

    void Update()
    {
        if(isAttacking == true)
        {

        }
    }
}
