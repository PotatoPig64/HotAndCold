using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishMovementScript : superklassEntity
{
    /// <summary>
    /// This is the JellyFish's movement script. The movement it does is randomized with both how often it will turn and what direction it will take.
    /// The jellyfish will have a chance to change directions every 3 to 7 seconds and it has 8 directions to pick from. There is a bool for every direction and when a direction bool is true, the entity will move in that direction.
    /// </summary>
    
    //vectors for the movement
    protected Vector3 currentMovement;
    protected Vector3 movement;

    //are used to restrict the jellyfish's movement
    public Transform maxNEMovement;
    public Transform maxSWMovement;

    //movement and lerp speed
    protected int movementValue;
    private float lerpSpeed = 0.25f;

    //variables for the timers
    private float timerMaxValue = 5;
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

    // Start is called before the first frame update
    void Start()
    {
        switchingDirections = false;
        timeUntilItProbablyWillTurn = 1;
    }

    // Update is called once per frame
    void Update()
    {

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

            //This will tell the jellyfish what direction it should move depending on the randomized number we just got in the line above
            switch (movementValue)
            {
                case 1:
                    if(switchingDirections == true) //These don't need to be in if satments but I'm too lazy to get rid of them right now
                    {
                        makeAllDirectionBoolsFalse();
                        SEMovement = true;
                        timerMaxValue = Random.Range(3f, 7f); //decides for how long (between 3 and seven seconds) the jellyfish will move in the direction before changing again
                        timeUntilItProbablyWillTurn = timerMaxValue;
                    }
                    break;
                case 2:
                    if (switchingDirections == true)
                    {
                        makeAllDirectionBoolsFalse();
                        SWMovement = true;
                        timerMaxValue = Random.Range(3f, 7f);
                        timeUntilItProbablyWillTurn = timerMaxValue;
                    }
                    break;
                case 3:
                    if (switchingDirections == true)
                    {
                        makeAllDirectionBoolsFalse();
                        NWMovement = true;
                        timerMaxValue = Random.Range(3f, 7f);
                        timeUntilItProbablyWillTurn = timerMaxValue;
                    }
                    break;
                case 4:
                    if (switchingDirections == true)
                    {
                        makeAllDirectionBoolsFalse();
                        NEMovement = true;
                        timerMaxValue = Random.Range(3f, 7f);
                        timeUntilItProbablyWillTurn = timerMaxValue;
                    }
                    break;
                case 5:
                    if (switchingDirections == true)
                    {
                        makeAllDirectionBoolsFalse();
                        SMovement = true;
                        timerMaxValue = Random.Range(3f, 7f);
                        timeUntilItProbablyWillTurn = timerMaxValue;
                    }
                    break;
                case 6:
                    if (switchingDirections == true)
                    {
                        makeAllDirectionBoolsFalse();
                        EMovement = true;
                        timerMaxValue = Random.Range(3f, 7f);
                        timeUntilItProbablyWillTurn = timerMaxValue;
                    }
                    break;
                case 7:
                    if (switchingDirections == true)
                    {
                        makeAllDirectionBoolsFalse();
                        NMovement = true;
                        timerMaxValue = Random.Range(3f, 7f);
                        timeUntilItProbablyWillTurn = timerMaxValue;
                    }
                    break;
                case 8:
                    if (switchingDirections == true)
                    {
                        makeAllDirectionBoolsFalse();
                        WMovement = true;
                        timerMaxValue = Random.Range(3f, 7f);
                        timeUntilItProbablyWillTurn = timerMaxValue;
                    }
                    break;

            }
        }

        //these eigth if-statements are what moves the enemy
        //South east
        if(SEMovement == true)
        {
            MovementSE();
        }

        //South west
        if(SWMovement == true)
        {
            MovementSW();
        }

        //North west
        if(NWMovement == true)
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

        /*
         * Fix This!
         * I would do it now
         * but I really don't want to
         * 
        //these four if statements makes sure that the yellyfish stays within a sertain range
        if(transform.position.x >= maxNEMovement.position.x)
        {
            switchingDirections = true;
            if(switchingDirections == true)
            {
                timeUntilItProbablyWillTurn = timerMaxValue;
                makeAllDirectionBoolsFalse();
                WMovement = true;
                switchingDirections = false;
            }

        }
        if (transform.position.y >= maxNEMovement.position.y)
        {
            switchingDirections = true;
            if (switchingDirections == true)
            {
                timeUntilItProbablyWillTurn = timerMaxValue;
                makeAllDirectionBoolsFalse();
                SMovement = true;
                switchingDirections = false;
            }
        }
        if(transform.position.x <= maxSWMovement.position.x)
        {
            if (switchingDirections == true)
            {
                timeUntilItProbablyWillTurn = timerMaxValue;
                makeAllDirectionBoolsFalse();
                EMovement = true;
                switchingDirections = false;
            }
        }
        if(transform.position.y <= maxSWMovement.position.y)
        {
            switchingDirections = true;
            if (switchingDirections == true)
            {
                timeUntilItProbablyWillTurn = timerMaxValue;
                makeAllDirectionBoolsFalse();
                NMovement = true;
                switchingDirections = false;
            }
        }
        */

    }

    //method for when the jellyfish is moving towards south east
    void MovementSE()
    {
        Vector3 newPosition = new Vector3(transform.position.x + movespeed * Time.deltaTime, transform.position.y - movespeed * 0.5f * Time.deltaTime);
        movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
        transform.position = movement;
    }

    //jellyfishmovemnt to the south west
    void MovementSW()
    {
        Vector3 newPosition = new Vector3(transform.position.x - movespeed * Time.deltaTime, transform.position.y - movespeed * 0.5f * Time.deltaTime);
        movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
        transform.position = movement;
    }

    //movement to the north east
    void MovementNE()
    {
        Vector3 newPosition = new Vector3(transform.position.x + movespeed * Time.deltaTime, transform.position.y + movespeed * 0.5f * Time.deltaTime);
        movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
        transform.position = movement;
    }

    //movement to the north west
    void MovementNW()
    {
        Vector3 newPosition = new Vector3(transform.position.x - movespeed * Time.deltaTime, transform.position.y + movespeed * 0.5f * Time.deltaTime);
        movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
        transform.position = movement;
    }

    //movement north
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
    void makeAllDirectionBoolsFalse()
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
        if(collision.gameObject.tag.Equals("Ground")|| collision.gameObject.tag.Equals("Void"))
        {
            //tells it that if it collides with something it should turn 
            timeUntilItProbablyWillTurn = 0;
            body.enabled = false;
            Invoke("enableCollider", 0.5f);
        }

    }

    private void enableCollider()
    {
        body.enabled = true;
    }
}
