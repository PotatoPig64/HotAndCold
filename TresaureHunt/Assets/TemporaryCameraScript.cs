using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryCameraScript : MonoBehaviour
{
    /// <summary>
    /// this is a very camera script
    /// </summary>
    public GameObject target;
    public float movespeed;

    void Update()
    {
        if(Vector3.Distance(transform.position, target.transform.position) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, movespeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }
    }
}
