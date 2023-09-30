using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Vector3 destination;


    void Start()
    {
        Move(transform.position);
    }

    void Update()
    {
        //move the character towards the destination
        Location.currentLocation.walkable.PlaceCharacter(this, Vector3.MoveTowards(transform.position, destination, 5f * Time.deltaTime));
    }

    public void Move(Vector3 targetDestination, bool force = false)
    {
        if (force || Location.currentLocation.IsValidWalkDestination(targetDestination))
        {
            destination = targetDestination;
        }
    }
}
