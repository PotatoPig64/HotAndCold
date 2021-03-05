using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// This is the GameManager script. 
    /// It for example keeps track of current nodes and the gameOver bool. 
    /// </summary>

    //displays the current node in the inspector
    public Node currentNode;

    public static GameManager ins;
    public GameObject player;

    //the player's ridgidBody2D
    Rigidbody2D playerRB;

    public bool gameOver;


    private void Awake() 
    {
        //this is a bad singleton, but it gets the job done so it will have to do
        ins = this;

        //gives accses to the player's rigidbody2D
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        //makes sure the gameOver bool is false at the start
        gameOver = false;

    }

    private void FixedUpdate()
    {
        //makes the player fall when they're "over" a void
        if(currentNode.tag.Equals("Void"))
        {
            playerRB.gravityScale = 2f;
        }
        else 
        {
            playerRB.gravityScale = 0f;
        }

        if(gameOver == true)
        {
            Debug.Log("GameOver");
            //remeber to write this later!!!
        }
    }

}
