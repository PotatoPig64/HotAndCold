using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttackTrigger : MonoBehaviour
{
    /// <summary>
    /// Player's melee attack trigger.
    /// It is a collider that appeares when the player attacks, 
    /// and it is when the collider collides with an enemy the player can deal dmg to them
    /// 
    /// OBS! remeber to add this in the enemy script:
    /// //makes the enemy's health go down if it's hit by the player public void Damage(int Damage)  { health -= Damage;}
    /// You migth need to change the
    /// </summary>
    public int dmg = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided!");
        //checks if the collision is with a piraya
        if(collision.isTrigger != true && collision.CompareTag("Piraya"))
        {
            //sends a message to the enemy to take dmg
            Debug.Log("Attack!");
            collision.SendMessageUpwards("Damage", dmg);
        }
        //checks if the colission is with a pirate
        if(collision.isTrigger != true && collision.CompareTag("Pirate"))
        {
            //sends a message to the enemy to take dmg
            Debug.Log("Attack!");
            collision.SendMessageUpwards("Damage", dmg);
        }
    }
}
