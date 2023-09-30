using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkable : MonoBehaviour
{
    PolygonCollider2D walkableArea;

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
}
