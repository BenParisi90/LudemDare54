using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public static Location currentLocation;

    //list of walkable areas within the location
    public Walkable walkable;
    public bool isStartLocation = false;
    LocationDoor[] doors;

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

    void Start()
    {   
        if(isStartLocation)
        {
            //set the current location to this location
            currentLocation = this;
            //place the character at the start location
            Location.currentLocation.walkable.PlaceCharacter(PlayerController.instance.Character, PlayerController.instance.Character.transform.position);
            gameObject.SetActive(true);
        }
    }

    public void OnEnable()
    {
        //set the current location to this location
        currentLocation = this;
    }

    void Update()
    {

    }

    public Vector3 GetDoorLocation(int doorDestionationIndex)
    {
        foreach (LocationDoor door in doors)
        {
            if (door.DestinationLocationIndex == doorDestionationIndex)
            {
                return door.transform.position;
            }
        }
        return Vector3.zero;
    }
}
