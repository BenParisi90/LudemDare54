using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public static Location currentLocation;

    //list of walkable areas within the location
    public Walkable walkable;

    public bool IsValidWalkDestination(Vector3 destination)
    {
        return walkable.IsWithinWalkableArea(destination);
    }

    public void Start()
    {
        //set the current location to this location
        currentLocation = this;
        walkable = GetComponentInChildren<Walkable>();

    }

    void Update()
    {

    }
}
