using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownPiratMovementScript : superklassEntity
{
    /// <summary>
    /// This is the Pirate Clown's movement script, that decides who the enemy will move. 
    /// It also contains the code that allowes the enemy to notice the player and follow them.
    /// It is very similar to the jellyfish movement in some ways when it comes to the idle movement.
    /// </summary>
    
    public Vector3 currentMovement;
    protected Vector3 movement;

    //are used to restrict the jellyfish's movement
    public Transform maxNEMovement;
    public Transform maxSWMovement;

    //movement and lerp speed
    private int movementValue;
    public float lerpSpeed = 0.25f;

    //variables for the timers
    private float timerMaxValue = 4;
    private float timeUntilItProbablyWillTurn;

    private bool switchingDirections;

    //bools for the different movement directions
    private bool SWMovement;
    private bool SEMovement;
    private bool NWMovement;
    private bool NEMovement;
    private bool SMovement;
    private bool NMovement;
    private bool EMovement;
    private bool WMovement;

    private bool idleWalk;
    private bool playerIsInRange;


    void Start()
    {
        idleWalk = true;
        playerIsInRange = false;
        timeUntilItProbablyWillTurn = 1.5f;

        checkRadius = 1.5f;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (idleWalk == true)
        {
            movespeed = 1;

            Debug.Log(timeUntilItProbablyWillTurn);
            //countdown for the timer
            if (timeUntilItProbablyWillTurn > 0)
            {
                switchingDirections = false;
                timeUntilItProbablyWillTurn -= Time.deltaTime;
            }

            //is used when the timer is at zero, which means that a new movement direction will be randomized and picked
            if (timeUntilItProbablyWillTurn <= 0)
            {
                switchingDirections = true;
                //randomizes a value between 1 and 8
                int randomNumber = (int)Random.Range(1f, 8f);
                movementValue = randomNumber;

                IdleWalk();
            }

            //these eigth if-statements are what moves the enemy
            //South east
            if (SEMovement == true)
            {
                MovementSE();
            }

            //South west
            if (SWMovement == true)
            {
                MovementSW();
            }

            //North west
            if (NWMovement == true)
            {
                MovementNW();
            }

            //North east
            if (NEMovement == true)
            {
                MovementNE();
            }

            //North
            if (NMovement == true)
            {
                MovementN();
            }

            //East
            if (EMovement == true)
            {
                MovementE();
            }

            //South
            if (SMovement == true)
            {
                MovementS();
            }

            //West
            if (WMovement == true)
            {
                MovementW();
            }
        }

        //will make the enemy follow th player if the player is in range
        if (playerIsInRange)
        {
            idleWalk = false;
            FollowPlayer();
        }
        else { idleWalk = true; }

        //checks if the player is in range
        if (Vector3.Distance(transform.position, target.position) < checkRadius)
        {
            playerIsInRange = true;
        }
        else { playerIsInRange = false; }
    }

    //is used when the enemy doesn't see the player/when the player is out of range
    void IdleWalk()
    {

        //This will tell the enemy what direction it should move depending on a randomized number
        switch (movementValue)
        {
            case 1:
                if (switchingDirections == true) //These don't need to be in if satments but I'm too lazy to get rid of them right now
                {
                    MakeAllDirectionBoolsFalse();
                    SEMovement = true;
                    timerMaxValue = Random.Range(3f, 7f); //decides for how long (between 3 and seven seconds) the jellyfish will move in the direction before changing again
                    timeUntilItProbablyWillTurn = timerMaxValue;
                }
                break;
            case 2:
                if (switchingDirections == true)
                {
                    MakeAllDirectionBoolsFalse();
                    SWMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
                }
                break;
            case 3:
                if (switchingDirections == true)
                {
                    MakeAllDirectionBoolsFalse();
                    NWMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
                }
                break;
            case 4:
                if (switchingDirections == true)
                {
                    MakeAllDirectionBoolsFalse();
                    NEMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
                }
                break;
            case 5:
                if (switchingDirections == true)
                {
                    MakeAllDirectionBoolsFalse();
                    SMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
                }
                break;
            case 6:
                if (switchingDirections == true)
                {
                    MakeAllDirectionBoolsFalse();
                    EMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
                }
                break;
            case 7:
                if (switchingDirections == true)
                {
                    MakeAllDirectionBoolsFalse();
                    NMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
                }
                break;
            case 8:
                if (switchingDirections == true)
                {
                    MakeAllDirectionBoolsFalse();
                    WMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
                }
                break;
        }       
    }


    //void that makes the enemy follow the player 
    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
    }

    //these next eigth methods are for moving in different directions
    //method for moving towards south east
    void MovementSE()
    {
        Vector3 newPosition = new Vector3(transform.position.x + movespeed * Time.deltaTime, transform.position.y - movespeed * 0.5f * Time.deltaTime);
        movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
        transform.position = movement;
    }

    //south west
    void MovementSW()
    {
        Vector3 newPosition = new Vector3(transform.position.x - movespeed * Time.deltaTime, transform.position.y - movespeed * 0.5f * Time.deltaTime);
        movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
        transform.position = movement;
    }

    //north east
    void MovementNE()
    {
        Vector3 newPosition = new Vector3(transform.position.x + movespeed * Time.deltaTime, transform.position.y + movespeed * 0.5f * Time.deltaTime);
        movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
        transform.position = movement;
    }

    //north west
    void MovementNW()
    {
        Vector3 newPosition = new Vector3(transform.position.x - movespeed * Time.deltaTime, transform.position.y + movespeed * 0.5f * Time.deltaTime);
        movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
        transform.position = movement;
    }

    //north
    void MovementN()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + movespeed * Time.deltaTime);
        movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
        transform.position = movement;
    }

    //south
    void MovementS()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y - movespeed * Time.deltaTime);
        movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
        transform.position = movement;
    }

    //west
    void MovementW()
    {
        Vector3 newPosition = new Vector3(transform.position.x - movespeed * Time.deltaTime, transform.position.y);
        movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
        transform.position = movement;
    }

    //East
    void MovementE()
    {
        Vector3 newPosition = new Vector3(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
        movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
        transform.position = movement;
    }

    //method to make all the direction bools false
    void MakeAllDirectionBoolsFalse()
    {
        SMovement = false;
        NMovement = false;
        WMovement = false;
        EMovement = false;
        SWMovement = false;
        SEMovement = false;
        NEMovement = false;
        NWMovement = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Ground")|| collision.gameObject.tag.Equals("Void")) //will make the enemy change directions if the collide with a collider
        {
            timeUntilItProbablyWillTurn = 0;
        }
    }
}
