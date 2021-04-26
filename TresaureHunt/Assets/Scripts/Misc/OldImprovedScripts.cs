using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldImprovedScripts : MonoBehaviour
{
    /// <summary>
    /// This stuff comes from the old jumping mechanics and movement script for the player. 
    /// We, with the help of the teacher, managed to find a way better way to make the jumping work so I just threw the old code out, since it's complete shit, but I felt that I should probably save it incase I can use some of it elsewhere in the future
    /// </summary>
    private float jumptimeCounter;
    private float jumpTime = 0.75f;
    private float jumpForce = 2;
    public static bool isJumping;
    Vector3 beforeJumpPosition;
    Vector3 movement;
    private float moveSpeed = 2;
    private float lerpSpeed = 3;

    private Rigidbody2D rb;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //under waterjump
        if (Input.GetKey(KeyCode.Space)) { UnderWaterJump(); }

        //jumptime counter that counts down
        if (isJumping == true) { jumptimeCounter -= Time.deltaTime; }
        else { jumptimeCounter = jumpTime; }

        //changes the velocity depending how long the player has been jumping
        if (jumptimeCounter < jumpTime * 0.8f && jumptimeCounter > jumpTime * 0.6f) { rb.velocity = Vector2.up * jumpForce / 3; }
        if (jumptimeCounter < jumpTime * 0.6f && jumptimeCounter > jumpTime * 0.4f) { rb.velocity = Vector2.down * jumpForce / 3; }
        if (jumptimeCounter < jumpTime * 0.4f && jumptimeCounter > jumpTime * 0.2f) { rb.velocity = Vector2.down * jumpForce; }
        if (beforeJumpPosition.x == transform.position.x && jumptimeCounter < jumpTime * 0.1f || jumptimeCounter <= 0)
        {
            rb.velocity = Vector2.zero;
            isJumping = false;
        }

        if (Input.GetKey(KeyCode.W)) //NW 
        {
            Vector3 newPosition = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y + moveSpeed * 0.5f * Time.deltaTime);
            movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
            transform.position = movement;

        }
        if (Input.GetKey(KeyCode.A)) //SW
        {
            Vector3 newPosition = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y - moveSpeed * 0.5f * Time.deltaTime);
            movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
            transform.position = movement;
        }
        if (Input.GetKey(KeyCode.S)) //SE
        {
            Vector3 newPosition = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y - moveSpeed * 0.5f * Time.deltaTime);
            movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
            transform.position = movement;
        }
        if (Input.GetKey(KeyCode.D)) //NE
        {
            Vector3 newPosition = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y + moveSpeed * 0.5f * Time.deltaTime);
            movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
            transform.position = movement;
        }
    }
    public void UnderWaterJump()
    {
        isJumping = true;
        rb.velocity = Vector2.up * jumpForce;
        jumptimeCounter = jumpTime;
        beforeJumpPosition = transform.position;
    }
}
