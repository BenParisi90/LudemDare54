using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    public static LocationManager instance;

    Location currentLocation;
    public Location CurrentLocation => currentLocation;

    Location[] locations;

    void Awake()
    {
        instance = this;
        
        //turn on the game objects of all my children
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        locations = GetComponentsInChildren<Location>();
        foreach (Location location in locations)
        {
            location.Init();
        }
    }

    void Start()
    {
        ResetGame();
        GameState.instance.ResetGameAction += ResetGame;
    }

    void ResetGame()
    {
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
        location.Load();
        currentLocation.gameObject.SetActive(true);
        currentLocation.walkable.PlaceCharacter(PlayerController.instance.Character, PlayerController.instance.Character.transform.position);
    }

    public void ChangeLocation(Location oldLocation, Location newLocation)
    {
        oldLocation.gameObject.SetActive(false);
        Debug.Log("change location and reset destination");
        //place the player at the door to the old location
        foreach(LocationDoor door in newLocation.Doors)
        {
            if(door.DestinationLocation == oldLocation)
            {
                PlayerController.instance.transform.position = door.transform.position + door.Interactable.InteractionOffset;
                break;
            }
        }
        SetCurrentLocation(newLocation);
        PlayerController.instance.Character.ResetDestination();
    }
}
