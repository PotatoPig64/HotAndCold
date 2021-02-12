using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FirstNodeAwakeScript : Node
{
    /// <summary>
    /// This script is assigned to the first node tha player starts on when the game begins.
    /// </summary>

    private float timeSinceStart = 0;
    private void Awake()
    {
        Col = GetComponent<TilemapCollider2D>();
    }
    //sets the current node to who ever has this script
    private void Start()    
    {
        Arrive();
    }
    private void FixedUpdate()
    {
        timeSinceStart += Time.deltaTime;
        //this will destroy the script when it no longer is the current node 
        //(the timer is here to make sure it doesn't get destroyed before it is set as the currentNode at the begining of the game)
        if(GameManager.ins.currentNode != this && timeSinceStart > 0.5f) 
        {
            Destroy(this);
        }
    }
}
