using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Highlightable : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;
    public PolygonCollider2D PolygonCollider2D => polygonCollider2D;
    public SpriteShapeRenderer spriteShapeRenderer;

    [SerializeField]
    CursorType cursorType;
    public CursorType CursorType => cursorType;

    void Awake()
    {
        polygonCollider2D = GetComponentInChildren<PolygonCollider2D>();
    }

    //if the mouse is over the walkable area, show the boot cursor
    void OnMouseEnter()
    {
        //Debug.Log("Setting cursor to " + cursorType);
        CursorManager.instance.SetCursor(cursorType);
    }

    void OnMouseExit()
    {
        CursorManager.instance.SetCursor(CursorType.DEFAULT);
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
