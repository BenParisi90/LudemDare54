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
    Character[] characters;
    public Character[] Characters => characters;

    public bool IsValidWalkDestination(Vector3 destination)
    {
        return walkable.IsWithinWalkableArea(destination);
    }

    public void Init()
    {
        walkable = GetComponentInChildren<Walkable>();
        gameObject.SetActive(isStartLocation);
        doors = GetComponentsInChildren<LocationDoor>();
        characters = GetComponentsInChildren<Character>();
        foreach(Character character in characters)
        {
            walkable.PlaceCharacter(character, character.transform.position);
        }
    }
}
