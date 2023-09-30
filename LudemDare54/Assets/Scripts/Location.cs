using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public static Location currentLocation;

    //list of walkable areas within the location
    public List<Walkable> walkableAreas = new List<Walkable>();

    public Walkable IsValidWalkDestination(Vector3 destination)
    {
        //check if the destination is within any of the walkable areas
        foreach (Walkable walkable in walkableAreas)
        {
            if (walkable.IsWithinWalkableArea(destination))
            {
                return walkable;
            }
        }
        return null;
    }

    public void Start()
    {
        //set the current location to this location
        currentLocation = this;

    }

    void Update()
    {

    }
}
