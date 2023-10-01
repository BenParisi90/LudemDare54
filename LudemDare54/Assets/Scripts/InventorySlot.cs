using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public InvItem Item;

    void Awake()
    {
        AssignItem(Item);
    }

    public void AssignItem(InvItem item)
    {
        //loop thorugh the children of the slot and turn on the correct item
        for (int j = 0; j < transform.childCount; j++)
        {
            transform.GetChild(j).gameObject.SetActive(j == (int)item);
        }
    }
}
