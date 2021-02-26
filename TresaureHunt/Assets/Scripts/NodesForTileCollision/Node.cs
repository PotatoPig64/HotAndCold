using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Node : MonoBehaviour
{
    /// <summary>
    /// This is a node script that tells the GameManager which node is the current node/where the player is and also does other stuff.
    /// </summary>

    public List<Node> reachableNodes = new List<Node>();
    [HideInInspector]
    public TilemapCollider2D Col;

    float wait;
    float waitingTime = 1f;
    private bool waiiiit = false;

    void Awake()
    {
        Col = GetComponent < TilemapCollider2D>();      
    }

    //sets the current node
    public void Arrive()
    {
        //leaves the currentNode if there is one
        if(GameManager.ins.currentNode != null) { GameManager.ins.currentNode.Leave(); }

        //sets the currentNode
        GameManager.ins.currentNode = this;

        //deactivates the current node's collider
        if(Col != null) { Col.enabled = false; }

        Debug.Log("Reached the while loop");
        while (wait >= 0) { waiiiit = true; }
        Debug.Log("Passed the while loop");

        if(wait <= 0)
        {
            //activates all reachable nodes' colliders
            foreach (Node node in reachableNodes)
            {
                if (node.Col != null)
                {
                    node.Col.enabled = true;
                }
            }
            Debug.Log("Stuff is activated");
        }

        wait = waitingTime;
    }

    //leaves the current node
    public void Leave()
    {
        //deactivated all reachable nodes' colliders
        foreach(Node node in reachableNodes)
        {
            if(node.Col != null)
            {
                node.Col.enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Arrive();
        }
    }

    private void Update()
    {
        if(waiiiit == true)
        {
            wait -= Time.deltaTime;
        }
    }
}
