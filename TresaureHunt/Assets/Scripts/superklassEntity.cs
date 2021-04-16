using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superklassEntity : MonoBehaviour
{

    public float movespeed = 3.5f;
    float timeTurner = 3f;
    float timeTilTurn = 0f;
    public bool facingRight; //for the flip method
    public float health = 1; //for the health method
    public Transform target; //crates 'target' with coordinates
    public Transform playerCheck; //checks if player
    public float checkRadius;   //how close the player need to be
    public LayerMask whatIsPlayer; 
    private bool nearPLayer; //yes or no
    public BoxCollider2D body; //for their bodies

        public virtual void Movement()
        {

            nearPLayer = Physics2D.OverlapCircle(playerCheck.position, checkRadius, whatIsPlayer);

            if (nearPLayer == true)
            {
                timeTilTurn = 0f;
                transform.position = Vector3.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
            }

        }
         
        public virtual void Attack()
        {

            

        }

        public virtual void Health()
        {

            if (health <= 0.1f)
            {
                health = 1f;
            }

            /*is used when the player runns out of lives
            if (health == 0)
            {
            managerScript.gameOver = true;
            }*/

        }

        public virtual void Oncollision(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {

            }

            if (collision.gameObject.tag.Equals("Wall"))
            {

            }

            if (collision.gameObject.tag.Equals("Jellyfish"))
            {

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

   

