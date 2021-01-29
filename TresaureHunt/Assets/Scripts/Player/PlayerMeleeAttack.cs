using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : Player
{
    public Collider2D AttackTrigger;


    private void Awake()
    {
        //makes sure that teh attack collider is not enabled when the game starts
        AttackTrigger.enabled = false;
        meleeAttackCooldown = 3;
    }


    // Update is called once per frame
    void Update()
    {
        //checks if the player is attacking
        if(Input.GetKeyDown(KeyCode.RightShift) && !isAttacking ) 
        {
            isAttacking = true;
            meeleAttackTimer = meleeAttackCooldown;

            //enables the attack trigger
            AttackTrigger.enabled = true;
        }
        if(isAttacking == true)
        {
            //attack cooldown timer
            if(meeleAttackTimer > 0)
            {
                meeleAttackTimer -= Time.deltaTime;
            }
            if(meeleAttackTimer <= 0)
            {
                isAttacking = false;
                AttackTrigger.enabled = false;
            }
        }
    }
}
