using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteShapeManager : MonoBehaviour
{
    public static SpriteShapeManager instance;
    ObjectPool objectPool;
    public List<Color> colors;

    void Awake()
    {
        instance = this;

        objectPool = GetComponent<ObjectPool>();
    }

    public void ClearSpriteShapes()
    {
        objectPool.ReturnAllObjects();
    }

    public void AssignSpriteShape(Highlightable highlightable)
    {
        GameObject spriteShape = objectPool.GetObject();
        spriteShape.transform.position = highlightable.transform.position;
        SpriteShapeController spriteShapeController = spriteShape.GetComponent<SpriteShapeController>();
        SpriteShapeRenderer spriteShapeRenderer = spriteShape.GetComponent<SpriteShapeRenderer>();
        spriteShapeRenderer.color = colors[(int)highlightable.CursorType];
        highlightable.spriteShapeRenderer = spriteShapeRenderer;
        PolygonCollider2D polygonCollider2D = highlightable.PolygonCollider2D;
        spriteShape.SetActive(true);

        // Get the Spline component
        Spline spline = spriteShapeController.spline;
        spline.Clear();
        //set the points of hte spline to match the walkable area
        Vector2[] points = polygonCollider2D.points;
        //set the number of points in the spline to match the number of points in the walkable area
        for (int i = 0; i < points.Length; i++)
        {
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
}
