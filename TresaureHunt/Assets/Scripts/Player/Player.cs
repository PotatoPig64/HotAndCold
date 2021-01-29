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
    private float moveSpeed = 2;
    private float lerpSpeed = 3;

    //Jump
    private float jumptimeCounter;
    private float jumpTime = 0.75f;
    private float jumpForce = 3;
    private bool isJumping;
    Vector3 beforeJumpPosition;

    //melee attack
    public bool isAttacking;
    public float meeleAttackTimer;
    public float meleeAttackCooldown = 3;

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
        isUnderWater = true;
        jumptimeCounter = jumpTime;

    }

    private void FixedUpdate()
    {

        if(isUnderWater == true)
        {
            //underwater movement
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 newPosition = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y + moveSpeed * 0.5f * Time.deltaTime);
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));

            }
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 newPosition = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y - moveSpeed * 0.5f * Time.deltaTime);
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
            }
            if (Input.GetKey(KeyCode.S))
            {
                Vector3 newPosition = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y - moveSpeed * 0.5f * Time.deltaTime);
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector3 newPosition = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y + moveSpeed * 0.5f * Time.deltaTime);
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
            }

            //under waterjump
            if (Input.GetKey(KeyCode.Space)){ UnderWaterJump(); }

            //jumptime counter that counts down
            if (isJumping == true) {  jumptimeCounter -= Time.deltaTime;}
            else { jumptimeCounter = jumpTime; }

            //changes the velocity depending how long the player has been jumping
            if(jumptimeCounter < jumpTime*0.8f && jumptimeCounter > jumpTime * 0.6f) { rb.velocity = Vector2.up * jumpForce / 3;}
            if(jumptimeCounter < jumpTime*0.6f && jumptimeCounter > jumpTime*0.4f) { rb.velocity = Vector2.down * jumpForce/3; }
            if(jumptimeCounter < jumpTime*0.4f && jumptimeCounter > jumpTime * 0.2f) { rb.velocity = Vector2.down * jumpForce;}
            if (beforeJumpPosition.x == transform.position.x && jumptimeCounter < jumpTime* 0.1f || jumptimeCounter <= 0)
            {
                rb.velocity = Vector2.zero;
                isJumping = false;
            }

          
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
