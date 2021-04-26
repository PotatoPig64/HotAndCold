using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTesScript : MonoBehaviour
{
    /// <summary>
    /// this is a test script that will be removed later
    /// </summary>
    public float currentHealth = 1;

    void Update()
    {
        if(currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int Damage) 
    { 
        currentHealth -= Damage;
        Debug.Log("I have taken dmg");
    }
}
