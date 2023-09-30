using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Highlightable : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;
    SpriteShapeController spriteShapeController;
    SpriteShapeRenderer spriteShapeRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteShapeController = GetComponentInChildren<SpriteShapeController>();
        spriteShapeRenderer = GetComponentInChildren<SpriteShapeRenderer>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        // Get the Spline component
        Spline spline = spriteShapeController.spline;
        //set the points of hte spline to match the walkable area
        Vector2[] points = polygonCollider2D.points;
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

    void Update()
    {
        //if I'm holding dowwn the q button, enable the walkable area, otherwise disable it
        if (Input.GetKey(KeyCode.Q))
        {
            spriteShapeRenderer.enabled = true;
        }
        else
        {
            spriteShapeRenderer.enabled = false;
        }
    }
}
