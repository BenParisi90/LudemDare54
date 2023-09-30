using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public void Move()
    {
        
        //get the destination from the mouse click
        Vector3 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        destination.z = transform.position.z;

        //check if the destination is valid
        if (Location.currentLocation.IsValidWalkDestination(destination))
        {
            //move the character to the destination
            transform.position = destination;
        }
    }
}
