using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Walkable : MonoBehaviour
{
    PolygonCollider2D walkableArea;

    public float topScale = 1f;
    public float bottomScale = 1f;

    void Start()
    {
        //get the PolygonCollider2D component
        walkableArea = GetComponent<PolygonCollider2D>();

    }

    public bool IsWithinWalkableArea(Vector3 destination)
    {
        //convert the destination to a Vector2
        Vector2 destination2D = new Vector2(destination.x, destination.y);

        //check if the destination is within the walkable area
        return walkableArea.OverlapPoint(destination2D);
    }

    public Vector3 ClosestPoint(Vector3 destination)
    {
        //convert the destination to a Vector2
        Vector2 destination2D = new Vector2(destination.x, destination.y);

        //get the closest point on the walkable area to the destination
        Vector2 closestPoint = walkableArea.ClosestPoint(destination2D);

        //return the closest point as a Vector3
        return new Vector3(closestPoint.x, closestPoint.y, destination.z);
    }

    public void PlaceCharacter(Character character, Vector3 destionation)
    {
        //place the character at the destination
        character.transform.position = destionation;
        //percent distance between the top and bottom of the walkable area
        float percent = (destionation.y - walkableArea.bounds.min.y) / (walkableArea.bounds.max.y - walkableArea.bounds.min.y);
        //scale the character based on the percent
        character.transform.localScale = Vector3.Lerp(Vector3.one * bottomScale, Vector3.one * topScale, percent);
    }
}
