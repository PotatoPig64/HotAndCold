using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMainScript : superklassEntity
{
    //misc
    public static bool isUnderWater;
    public Rigidbody2D rb;
    public BoxCollider2D boxColl;
    public Collider2D meleeAttackTrigger;
    public static bool hasFallenIntoTheVoid; //remeber to write this later while working on the collision

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
    protected float bulletSpeed;
    protected float coolDownRangeAttack;
    protected float coolDownTimerRangeAttack;

    private float moveInput;

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
        else { LandInputHandler(); }
    }

    private void FixedUpdate()
    {

        if (isUnderWater == true)
        {
            moveSpeed = 2;
            //underwater movespeeed
            // underwater movement and jump
            if (isJumping)
            {
                boxColl.enabled = false;
                //calls for the underwater jump handler if the player is jumping
                UnderWaterJumpHandler();
            }
            else//if you aint jumping, you're walking
            {
                boxColl.enabled = true;
                UnderWaterMovementHandler();
            }

            if (facingRight && moveInput > 0) { FlipSprites(); }
            else if(!facingRight && moveInput < 0) { FlipSprites(); }
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

            //check the horizontal direction the player is moving and decides if the sprite needs to be flipped
            if(beforeJumpPosition.x > landingPosition.x)
            {
                
                facingRight = true;
               
            }
            else 
            {
                facingRight = false; 
            }
        }
        else
        {
            timeElapsed += Time.fixedDeltaTime * moveSpeed / landingDistance;

            //if the time elapsed is less or equal than 1, the player will jump
            if (timeElapsed <= 1f)
            {
                beforeJumpPosition = Vector2.MoveTowards(beforeJumpPosition, landingPosition, Time.fixedDeltaTime * moveSpeed);
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
        if (!GameManager.ins.currentNode.tag.Equals("Void"))
        {
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        }
    }


    void UnderWaterInputHandler()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector2(horizontal * 0.5f, vertical * 0.5f);

        moveInput = Input.GetAxis("Horizontal");

        //begins the jumping process id space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }


    void OnGroundMovement()
    {

        moveSpeed = 3f;
        if (isJumping)
        {
            LandJumpHandler();
        }
        else
        {
            LandMovementHandler();
        }


    }

    void LandJumpHandler()
    {
         if (isGrounded)
         {
             beforeJumpPosition = rb.position;
             landingPosition = beforeJumpPosition + movement.normalized * moveSpeed;
             landingDistance = Vector2.Distance(landingPosition, beforeJumpPosition);
             timeElapsed = 0f;
             isGrounded = false;
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
                 isGrounded = true;
             }     
          }
     

    }

    void LandMovementHandler()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    void LandInputHandler()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector2(horizontal, vertical);

        if (Input.GetKeyDown("space"))
        {
            isJumping = true;
        }
    }


    void FlipSprites()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}


