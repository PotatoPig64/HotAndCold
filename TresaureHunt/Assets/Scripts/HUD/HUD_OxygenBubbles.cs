using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD_OxygenBubbles : MonoBehaviour
{   
    /// <summary>
    /// This is a HUD script that controlls the airbubbles/oxygenbubbles we see on the screen while playing
    /// it is directly conected to the players health script.
    /// </summary>
    public List<Image> airBubbles = new List<Image>();

    void Awake()
    {
        //makes sure all the images are enabled when te game starts
        foreach (Image image in airBubbles)
        {
            image.enabled = true;
        }
    }


    void Update()
    {
        //all these if statments takes away a bubble depending on hom much air the player currently has
        if(PlayerHealthAndOxygenMechanics.currentAmountOfAir <= 9)
        {
            airBubbles[9].enabled = false;
        }
        if (PlayerHealthAndOxygenMechanics.currentAmountOfAir <= 8)
        {
            airBubbles[8].enabled = false;
        }
        if (PlayerHealthAndOxygenMechanics.currentAmountOfAir <= 7)
        {
            airBubbles[7].enabled = false;
        }
        if (PlayerHealthAndOxygenMechanics.currentAmountOfAir <= 6)
        {
            airBubbles[6].enabled = false;
        }
        if (PlayerHealthAndOxygenMechanics.currentAmountOfAir <= 5)
        {
            airBubbles[5].enabled = false;
        }
        if (PlayerHealthAndOxygenMechanics.currentAmountOfAir <= 4)
        {
            airBubbles[4].enabled = false;
        }
        if (PlayerHealthAndOxygenMechanics.currentAmountOfAir <= 3)
        {
            airBubbles[3].enabled = false;
        }
        if (PlayerHealthAndOxygenMechanics.currentAmountOfAir <= 2)
        {
            airBubbles[2].enabled = false;
        }
        if (PlayerHealthAndOxygenMechanics.currentAmountOfAir <= 1)
        {
            airBubbles[1].enabled = false;
        }
        if (PlayerHealthAndOxygenMechanics.currentAmountOfAir <= 0)
        {
            airBubbles[0].enabled = false;
        }

        //enables all the airbubbles' sprites when the player breathes 
        if (PlayerHealthAndOxygenMechanics.tookABreath == true)
        {
            foreach(Image image in airBubbles)
            {
                image.enabled = true;
            }
        }
    }
}
