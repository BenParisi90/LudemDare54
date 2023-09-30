using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager instance; // A reference to the CursorManager in the scene
    public Texture2D[] cursorTextures; // The texture to use for the cursor
    public Vector2 hotSpot = Vector2.zero; // The hotspot of the cursor


    void Start()
    {
        // Set the CursorManager instance
        instance = this;
    }

    public void SetCursor(CursorType cursorType)
    {
        if(cursorType == CursorType.DEFAULT)
        {
            Cursor.SetCursor(null, new Vector2(), CursorMode.Auto);
            return;
        }
        else
        {
            // Set the cursor texture and hotspot
            Cursor.SetCursor(cursorTextures[(int)cursorType], new Vector2(), CursorMode.Auto);
        }
    }
}

public enum CursorType
{
    WALK,
    INTERACT,
    EXIT,
    DEFAULT,
}