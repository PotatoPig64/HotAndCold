using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfThisIsHereYouCanDeleteItItWasOnlyForTesting : MonoBehaviour
{
    [SerializeField] AnimationCurve curveY;
    Rigidbody2D rb;
    Vector2 movement;
    Vector2 beforeJumpPosition;
    Vector2 landingPosition;
    float landingDistance;
    float moveSpeed = 2f;
    float timeElapsed = 0f;
    bool isgrounded = true;
    bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputHandler();
    }

    void FixedUpdate()
    {
        if (isJumping)
        {
            JumpHandler();
        }
        else
        {
            MovementHandler();
        }
    }
    void JumpHandler()
    {
        if (isgrounded)
        {
            beforeJumpPosition = rb.position;
            landingPosition = beforeJumpPosition + movement.normalized * moveSpeed;
            landingDistance = Vector2.Distance(landingPosition, beforeJumpPosition);
            timeElapsed = 0f;
            isgrounded = false;
        }
        else
        {
            timeElapsed += Time.fixedDeltaTime * moveSpeed / landingDistance;
            if (timeElapsed <= 1f)
            {
                beforeJumpPosition = Vector2.MoveTowards(beforeJumpPosition, landingPosition, Time.fixedDeltaTime * moveSpeed);
                rb.MovePosition(new Vector2(beforeJumpPosition.x, beforeJumpPosition.y + curveY.Evaluate(timeElapsed)));
            }
            else
            {
                isJumping = false;
                isgrounded = true;
            }
        }
    }

    void MovementHandler()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    void InputHandler()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector2(horizontal, vertical);

        if (Input.GetKeyDown("space"))
        {
            Debug.Log("you've pressed the spacebar");
            isJumping = true;
        }
    }
}
