using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBubbleColliderScript : MonoBehaviour
{
    /// <summary>
    /// This is the airbubble's coillider script. The air bubbles have colliders to detect if the player walks into them or not, 
    /// but since the player should be able to pass through the bubbles, the airbubble's colliders must be able to activate and deactivate themselves - hence why this script excists
    /// </summary>
    
    private BoxCollider2D col;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if (col.enabled == false)
        {
            //activates the collider again after one second
            Invoke("ActivateCollider", 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //deactivates the airbibbles collider when the player comes incontact with it
        if (collision.gameObject.tag.Equals("Player"))
        {
            col.enabled = false;
        }
    }

    private void ActivateCollider()
    {
        col.enabled = true;
    }
}
