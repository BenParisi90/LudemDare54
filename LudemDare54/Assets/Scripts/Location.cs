using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public static Location currentLocation;

    //list of walkable areas within the location
    public Walkable walkable;
    public bool isStartLocation = false;

    public bool IsValidWalkDestination(Vector3 destination)
    {
        return walkable.IsWithinWalkableArea(destination);
    }

    void Awake()
    {
        walkable = GetComponentInChildren<Walkable>();
        gameObject.SetActive(isStartLocation);
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
}
