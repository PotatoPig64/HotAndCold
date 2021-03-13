using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Health : MonoBehaviour
{
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
