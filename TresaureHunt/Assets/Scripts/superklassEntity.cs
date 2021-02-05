using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superklassEntity : MonoBehaviour
{
    
        void Movement()
        {




        }
         
        void Attack()
        {



        }

        void Health()
        {
            float Health = 1;

            if (Health <= 0.1f)
            {
                Health = 1f;
            }

            /*is used when the player runns out of lives
            if (Health == 0)
            {
            managerScript.gameOver = true;
            }*/

    }

        void Oncollision()
        {



        }


    }

   

