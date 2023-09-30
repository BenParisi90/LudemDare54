using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTypeSetter : MonoBehaviour
{
    [SerializeField]
    CursorType cursorType;

    //if the mouse is over the walkable area, show the boot cursor
    void OnMouseEnter()
    {
        Debug.Log("Setting cursor to " + cursorType);
        CursorManager.instance.SetCursor(cursorType);
    }

    void OnMouseExit()
    {
        CursorManager.instance.SetCursor(CursorType.DEFAULT);
    }
}
