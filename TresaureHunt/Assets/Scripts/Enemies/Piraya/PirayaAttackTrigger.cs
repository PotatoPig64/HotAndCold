using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirayaAttackTrigger : MonoBehaviour
{
    /// <summary>
    /// This works exactly in the same way as the player's attack trigger, so read there if you want an explenation.
    /// </summary>
    public int dmg = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger != true && collision.CompareTag("Player"))
        {
            //sends a message to the player to take dmg
            collision.SendMessageUpwards("Damage", dmg);
        }
    }
}
