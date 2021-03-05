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
        Debug.Log(GameManager.ins.currentNode);

        //deactivates the current node's collider
        if(Col != null) { Col.enabled = false; }

        //delayes the activation of the reachable nodes so that the player has time to pass throught before the collider is activated
        Invoke("ActivateReachableNodes", 0.5f);

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


    //checks for collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Arrive();
        }
    }


    //activates all reachable nodes' colliders
    void ActivateReachableNodes() 
    {
        foreach (Node node in reachableNodes)
        {
            if (node.Col != null)
            {
                node.Col.enabled = true;
            }
        }
    }

}
