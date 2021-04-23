using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirayaMovement : MonoBehaviour
{
    float movespeed = 3.5f;
    float timeTurner = 3f;
    float timeTilTurn = 0f;
    bool facingRight;
    private Transform target;
    public Transform playerCheck;
    public float checkRadius;
    public LayerMask whatIsPlayer;
    private bool nearPLayer;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        nearPLayer = Physics2D.OverlapCircle(playerCheck.position, checkRadius, whatIsPlayer);
        if (nearPLayer == true)
        {
            timeTilTurn = 0f;
            transform.position = Vector3.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
        }
        else
        {
            if (timeTilTurn > -1)
            {
                timeTilTurn -= Time.deltaTime;
            }
            if (timeTilTurn <= -1)
            {
                timeTilTurn = timeTurner;
            }
            if (timeTilTurn >= 2f)
            {
                facingRight = true;
                Vector3 sideMove = new Vector3(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
                transform.position = sideMove;
                flip();
            }
            if (timeTilTurn <= 2f)
            {
                facingRight = false;
                Vector3 sideMove = new Vector3(transform.position.x - movespeed * Time.deltaTime, transform.position.y);
                transform.position = sideMove;
                flip();
            }



        }

        void flip()
        {
            facingRight = !facingRight;
            Vector3 scaler = transform.localScale;
            scaler.x *= -1;
            transform.localScale = scaler;
        }
    }
}
