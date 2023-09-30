using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Vector3 destination;
    Walkable destinationWalkable;

    void Start()
    {
        Move(transform.position);
    }

    void Update()
    {
        //move the character towards the destination
        destinationWalkable.PlaceCharacter(this, Vector3.MoveTowards(transform.position, destination, 5f * Time.deltaTime));
    }

    public void Move(Vector3 targetDestination)
    {

        //check if the destination is valid
        Walkable walkable = Location.currentLocation.IsValidWalkDestination(targetDestination);
        if (walkable != null)
        {
            destinationWalkable = walkable;
            destination = targetDestination;
        }
    }
}
