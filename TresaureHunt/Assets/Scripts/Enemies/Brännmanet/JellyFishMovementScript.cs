using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : superklassEntity
{
    /// <summary>
    /// This is the JellyFish's movement script. The movement it does is randomized with both how often it will turn and what direction it will take.
    /// The jellyfish will have a chance to change directions every 3 to 7 seconds and it has 8 directions to pick from.
    /// </summary>
    /// 
    protected Vector3 currentMovement;
    protected Vector3 movement;
    public Vector3 maxNEMovement;
    public Vector3 maxSWMovement;

    protected int movementValue;
    public float lerpSpeed;
    private float timerMaxValue = 5;
    private float timeUntilItProbablyWillTurn;

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
        timeUntilItProbablyWillTurn = timerMaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeUntilItProbablyWillTurn > 0)
        {
            timeUntilItProbablyWillTurn -= Time.deltaTime;
        }

        if (timeUntilItProbablyWillTurn <= 0)
        {
            //randomizes a value between 1 and 4
            movementValue =  (int) Random.Range(1f, 8f);

            //This will tell the jellyfish what direction it should move depending on the randomized number we just got in the line above
            switch (movementValue)
            {
                case 1:
                    makeAllDirectionBoolsFalse();
                    SEMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
                    break;
                case 2:
                    makeAllDirectionBoolsFalse();
                    SWMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
                    break;
                case 3:
                    makeAllDirectionBoolsFalse();
                    NWMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
                    break;
                case 4:
                    makeAllDirectionBoolsFalse();
                    NEMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
                    break;
                case 5:
                    makeAllDirectionBoolsFalse();
                    SMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
                    break;
                case 6:
                    makeAllDirectionBoolsFalse();
                    EMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
                    break;
                case 7:
                    makeAllDirectionBoolsFalse();
                    NMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
                    break;
                case 8:
                    makeAllDirectionBoolsFalse();
                    WMovement = true;
                    timerMaxValue = Random.Range(3f, 7f);
                    timeUntilItProbablyWillTurn = timerMaxValue;
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

        if(transform.position.x >= maxNEMovement.x)
        {
            timeUntilItProbablyWillTurn = timerMaxValue;
            makeAllDirectionBoolsFalse();
            SMovement = true;
        }
        if (transform.position.y >= maxNEMovement.y)
        {

        }

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

    //East
    void MovementE()
    {
        Vector3 newPosition = new Vector3(transform.position.x - movespeed * Time.deltaTime, transform.position.y);
        movement = new Vector3(Mathf.Lerp(transform.position.x, newPosition.x, lerpSpeed), Mathf.Lerp(transform.position.y, newPosition.y, lerpSpeed));
        transform.position = movement;
    }

    //west
    void MovementW()
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
        //tells it that if it collides with something it should turn 
        timeUntilItProbablyWillTurn = 0;
    }

}
