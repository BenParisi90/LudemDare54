using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    //list of walkable areas within the location
    public Walkable walkable;
    public bool isStartLocation = false;
    LocationDoor[] doors;
    public LocationDoor[] Doors => doors;

    public bool IsValidWalkDestination(Vector3 destination)
    {
        return walkable.IsWithinWalkableArea(destination);
    }

    void Awake()
    {
        walkable = GetComponentInChildren<Walkable>();
        gameObject.SetActive(isStartLocation);
        doors = GetComponentsInChildren<LocationDoor>();
        if(isStartLocation)
        {
            gameObject.SetActive(true);
        }
    }
}
