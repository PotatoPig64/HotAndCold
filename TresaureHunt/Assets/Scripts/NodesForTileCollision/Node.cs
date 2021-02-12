using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Node : MonoBehaviour
{
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

        //deactivates the current node's collider
        if(Col != null) { Col.enabled = false; }

        //activates all reachable nodes' colliders
        foreach(Node node in reachableNodes)
        {
            if(node.Col != null)
            {
                node.Col.enabled = true;
            }
        }
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
}
