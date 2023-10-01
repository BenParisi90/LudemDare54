using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public InvItem Item;
    private bool isDragging = false;
    private Vector3 startPosition;
    Transform activeItem;

    void Awake()
    {
        AssignItem(Item);
    }

    public void AssignItem(InvItem item)
    {
        Item = item;
        if(item != InvItem.Count)
        {
            activeItem = transform.GetChild((int)item);
        }
        //loop thorugh the children of the slot and turn on the correct item
        for (int j = 0; j < transform.childCount; j++)
        {
            transform.GetChild(j).gameObject.SetActive(j == (int)item);
        }
    }

    //when you click on me, 
    void OnMouseDown()
    {
        if (Item != InvItem.Count)
        {
            Debug.Log("Start Drag");
            //start dragging the item
            isDragging = true;
            startPosition = activeItem.position;
            InventoryManager.instance.DraggedItem = Item;
        }
    }

    void OnMouseDrag()
    {
        
        if (isDragging)
        {
            Debug.Log("Dragging");
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeItem.position = new Vector3(mousePosition.x, mousePosition.y, activeItem.position.z);
        }
    }

    void OnMouseUp()
    {
        if(!isDragging)
        {
            return;
        }
        Debug.Log("Stop Drag");
        isDragging = false;
        InventoryManager.instance.DraggedItem = InvItem.Count;
        InventoryManager.instance.DraggedItemReleased?.Invoke(Item);

        // Check if the item was dropped in a valid location
        // If not, return the item to its original position
        if (!IsValidDropLocation())
        {
            activeItem.position = startPosition;
        }
    }

    bool IsValidDropLocation()
    {
        // Check if the item was dropped in a valid location
        // Return true if it was, false otherwise
        return false;
    }
}
