using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //misc
    public bool isUnderWater;
    private Rigidbody2D rb;
    private BoxCollider2D boxColl;
    public Collider2D meleeAttackTrigger;
    public Animator animator;
    public float moveSpeed;

    //ground check
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float checkRadius;

    //Jump
    private float jumptimeCounter;
    public float jumpTime;
    public float jumpForce;
    public float fallMultiplyer;
    public bool isJumping;

    //melee attack
    public bool isAttacking;
    private float meeleAttackTimer;
    public float meleeAttackCooldown;

    //rangeAttack
    public Transform bullet;
    public float bulletSpeed;
    public float coolDownRangeAttack;
    private float coolDownTimerRangeAttack;

    //breathing mechanics
    private float airMax;
    public float airCountdown;
    public bool isBreathing;
    public bool isDrowning;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isUnderWater = true;
    }

    private void FixedUpdate()
    {
        //checks if the player is on the ground or not
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if(isUnderWater == true)
        {
            //underwater movement
            if (Input.GetKey(KeyCode.W))
            {
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y + moveSpeed * 0.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y - moveSpeed * 0.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y - moveSpeed * 0.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y + moveSpeed * 0.5f * Time.deltaTime);
            }
            /*

            //jump
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                UnderWaterJump();
            }
            if(Input.GetKey(KeyCode.Space) && isJumping == true) //enables the player to choose how high they want to jump
            {
                if(jumptimeCounter > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumptimeCounter -= Time.deltaTime;
                }
                else 
                {
                    rb.gravityScale = 0.5f;
                    isJumping = false; 
                }
            }
            if (rb.velocity.y <= 0) //makes the jump a "videogame jump" aka the jump is not a perfect parabola 
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplyer - 1) * Time.deltaTime;
            }
            */
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnderWaterJump()
    {
        isJumping = true;
        rb.gravityScale = 1;
        rb.velocity = Vector2.up * jumpForce;
        jumptimeCounter = jumpTime;
    }
}
