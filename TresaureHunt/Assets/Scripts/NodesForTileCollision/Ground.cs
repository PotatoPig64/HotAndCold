using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ground : Node
{
    public EdgeCollider2D ColForWhenJumpingToHigherGround;

    private void FixedUpdate()
    {
        if (GameManager.ins.currentNode.tag.Equals("Ground"))
        {
            ColForWhenJumpingToHigherGround.enabled = true;
        }
        else { ColForWhenJumpingToHigherGround.enabled = false; }
    }
}
