using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishDmgScript : MonoBehaviour
{
    /// <summary>
    /// this is the Jellyfish's "attack" script, what happens is that if the player tuches the jellyfish the player will imideatly die.
    /// </summary>
    /// 
    public int dmg = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Player"))
        {
            //sends a message to the player to take dmg
            collision.SendMessageUpwards("Damage", dmg);
        }
    }

}
