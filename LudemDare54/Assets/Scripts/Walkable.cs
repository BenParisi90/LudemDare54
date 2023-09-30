using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Walkable : MonoBehaviour
{
    PolygonCollider2D walkableArea;
    SpriteShapeController spriteShapeController;

    public float topScale = 1f;
    public float bottomScale = 1f;

    void Start()
    {
        spriteShapeController = GetComponentInChildren<SpriteShapeController>();
        //get the PolygonCollider2D component
        walkableArea = GetComponent<PolygonCollider2D>();

        // Get the Spline component
        Spline spline = spriteShapeController.spline;
        //set the points of hte spline to match the walkable area
        Vector2[] points = walkableArea.points;
        //set the number of points in the spline to match the number of points in the walkable area
        Debug.Log(spline.GetPointCount());
        for (int i = 0; i < points.Length; i++)
        {
            Debug.Log(i);
            if(i >= spline.GetPointCount())
            {
                spline.InsertPointAt(i, points[i]);
            }
            else
            {
                spline.SetPosition(i, points[i]);
            }
            spline.SetTangentMode(i, ShapeTangentMode.Linear);
            spline.SetHeight(i, 0f);
        }

    }

    public bool IsWithinWalkableArea(Vector3 destination)
    {
        //convert the destination to a Vector2
        Vector2 destination2D = new Vector2(destination.x, destination.y);

        //check if the destination is within the walkable area
        return walkableArea.OverlapPoint(destination2D);
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
