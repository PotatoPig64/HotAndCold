using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Health : MonoBehaviour
{
    /// <summary>
    /// this is the script that keeps track over the hearts dissplayed on the HUD
    /// </summary>
    
    public Image heart1;
    public Image heart2;
    public Image heart3;

    private void Awake()
    {
        heart1.enabled = true;
        heart2.enabled = true;
        heart3.enabled = true;
    }
    void Update()
    {
        //depending on how many lifes the player has left, the different heart images will or will not be enabled
        if(PlayerHealthAndOxygenMechanics.health == 2)
        {
            heart3.enabled = false;
        }

        if(PlayerHealthAndOxygenMechanics.health == 1)
        {
            heart2.enabled = false;
        }
        if(PlayerHealthAndOxygenMechanics.health <= 0)
        {
            heart1.enabled = false;
        }
    }
}
