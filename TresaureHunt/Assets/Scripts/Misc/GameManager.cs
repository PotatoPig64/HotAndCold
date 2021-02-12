using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Node currentNode;
    public static GameManager ins;
    Rigidbody2D playerRB;

    private void Awake() 
    {
        //this is a very bad singleton, but it gets the job done
        ins = this;

        //gives accses to the player's rigidbody2D
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        //makes the player fall when they're "over" a void
        if(currentNode.tag.Equals("Void"))
        {
            Player.isGrounded = false;
            playerRB.gravityScale = 2f;
        }
        else 
        {
            Player.isGrounded = true;
            playerRB.gravityScale = 0f;
        }
    }

}
