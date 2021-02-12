using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FirstNodeAwakeScript : Node
{
    private void Awake()
    {
        Col = GetComponent<TilemapCollider2D>();
    }
    //sets the current node to who ever has this script
    private void Start()    
    {
        Arrive();
    }
}
