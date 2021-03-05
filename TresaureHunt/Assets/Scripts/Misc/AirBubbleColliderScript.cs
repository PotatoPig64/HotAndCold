using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBubbleColliderScript : MonoBehaviour
{
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
