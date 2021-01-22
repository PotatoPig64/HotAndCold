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
        rb.GetComponent<Rigidbody2D>(); //enables access to the player's rigidbody
        boxColl.GetComponent<BoxCollider2D>();// enables access to the player's boxcollider
    }

    private void FixedUpdate()
    {
        //checks if the player is on the ground or not
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //movement
        if (Input.GetKey(KeyCode.D)) { transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y); }
        if (Input.GetKey(KeyCode.A)) { transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y); }
        if (Input.GetKey(KeyCode.W)) { transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime, transform.position.z + moveSpeed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)) { transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime, transform.position.z - moveSpeed * Time.deltaTime); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
