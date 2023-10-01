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
    Highlightable[] highlightables;
    public Highlightable[] Highlightables => highlightables;

    public bool IsValidWalkDestination(Vector3 destination)
    {
        return walkable.IsWithinWalkableArea(destination);
    }

    public void Init()
    {
        walkable = GetComponentInChildren<Walkable>();
        doors = GetComponentsInChildren<LocationDoor>();
        characters = GetComponentsInChildren<Character>();
        highlightables = GetComponentsInChildren<Highlightable>();
    }

    void Start()
    {
        foreach(Character character in characters)
        {
            walkable.PlaceCharacter(character, character.transform.position);
        }
    }

    public void Load()
    {
        SpriteShapeManager.instance.ClearSpriteShapes();
        foreach(Highlightable highlightable in highlightables)
        {
            SpriteShapeManager.instance.AssignSpriteShape(highlightable);
        }
    }
}
