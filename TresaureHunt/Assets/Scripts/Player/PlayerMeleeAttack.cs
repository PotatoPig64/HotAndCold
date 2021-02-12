using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    /// <summary>
    /// The Player's melee attack script. 
    /// In here you'll for example find the attack cooldown if you need it.
    /// </summary>
 
    public bool isAttacking;
    public float meeleAttackTimer;
    public float meleeAttackCooldown = 3;
    public Collider2D AttackTrigger;


    private void Awake()
    {
        //makes sure that the attack collider is not enabled when the game starts
        AttackTrigger.enabled = false;
        meleeAttackCooldown = 3;
    }

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
            //dissables the attack collider after a second
            if(meeleAttackTimer < 2)
            {
                AttackTrigger.enabled = false;
            }
            //allowes the player to attack again
            if(meeleAttackTimer <= 0)
            {
                isAttacking = false;
            }
        }
    }
}
