using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    public static LocationManager instance;

    Location currentLocation;
    public Location CurrentLocation => currentLocation;

    Location[] locations;

    void Start()
    {
        instance = this;
        locations = GetComponentsInChildren<Location>();
        foreach (Location location in locations)
        {
            location.gameObject.SetActive(location.isStartLocation);
            if(location.isStartLocation)
            {
                SetCurrentLocation(location);
            }
        }
    }

    public void SetCurrentLocation(Location location)
    {
        currentLocation = location;
        currentLocation.gameObject.SetActive(true);
    }

    public void ChangeLocation(Location oldLocation, Location newLocation)
    {
        oldLocation.gameObject.SetActive(false);
        SetCurrentLocation(newLocation);
        Debug.Log("change location and reset destination");
        //place the player at the door to the old location
        foreach(LocationDoor door in newLocation.Doors)
        {
            if(door.DestinationLocation == oldLocation)
            {
                PlayerController.instance.transform.position = door.transform.position;
                break;
            }
        }
        PlayerController.instance.Character.ResetDestination();
    }
}
