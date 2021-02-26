﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Player : superklassEntity
{
    //misc
    public bool isUnderWater;
    public Rigidbody2D rb;
    private BoxCollider2D boxColl;
    public Collider2D meleeAttackTrigger;
    public bool hasFallenIntoTheVoid; //remeber to write this later while working on the collision

    [SerializeField] AnimationCurve curveY;

    public Animator animator;

    private float moveSpeed = 2;

    //Jump
    private float timeElapsed;
    public bool isJumping;
    public bool isGrounded;
    Vector2 beforeJumpPosition;
    Vector2 landingPosition;
    Vector2 movement;
    private float landingDistance;

    //rangeAttack
    public Transform bullet;
    private float bulletSpeed;
    private float coolDownRangeAttack;
    private float coolDownTimerRangeAttack;

    //breathing mechanics
    private float airMax;
    private float airCountdown;
    private bool isBreathing;
    private bool isDrowning;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        isUnderWater = true;

    }

    void Update()
    {
        //calls for the inputhandler method that checks after inputs
        if (isUnderWater) { UnderWaterInputHandler(); }
    }

    private void FixedUpdate()
    {

        if(isUnderWater == true)
        {

            // underwater movement and jump
            if (isJumping)
            {         
                //calls for the underwater jump handler if the player is jumping
                UnderWaterJumpHandler();
            }
            else//if you aint jumping, you're walking
            {
                UnderWaterMovementHandler();
            }

        }        
        
    }

    void UnderWaterJumpHandler()
    {
        if (isGrounded == true)
        {
            //the player's current position
            beforeJumpPosition = rb.position;

            //the position the player will land at
            landingPosition = beforeJumpPosition + movement.normalized * moveSpeed;

            //the distance the player will jump
            landingDistance = Vector2.Distance(landingPosition, beforeJumpPosition);

            timeElapsed = 0f;
            isGrounded = false;
        }
        else
        {
            timeElapsed += Time.fixedDeltaTime * moveSpeed/landingDistance;

            //if the time elapsed is less or equal than 1, the player will jump
            if(timeElapsed <= 1f)
            {
                beforeJumpPosition = Vector2.MoveTowards(beforeJumpPosition , landingPosition, Time.fixedDeltaTime * moveSpeed);
                rb.MovePosition(new Vector2(beforeJumpPosition.x, beforeJumpPosition.y + curveY.Evaluate(timeElapsed)));
            }
            //when timeElapsed is greater than 1, the jump is finished
            else
            {
                isJumping = false;
                isGrounded = true;
            }
        }
    }

    void UnderWaterMovementHandler() //moves the player. this is a very sad player movement :( I had a more fun one but I can't use it.
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }


    void UnderWaterInputHandler()
    {      
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector2(horizontal * 0.5f, vertical * 0.5f);
        

        //begins the jumping process id space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }


}
