using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    InventorySlot[] invSlots;

    void Awake()
    {
        instance = this;
        invSlots = GetComponentsInChildren<InventorySlot>();
    }

    public void AddItem(InvItem item)
    {
        //find the first empty slot
        for (int i = 0; i < invSlots.Length; i++)
        {
            if (invSlots[i].Item == InvItem.Count)
            {
                invSlots[i].AssignItem(item);
                return;
            }
        }
    }
}

public enum InvItem
{
    SPOON,
    Count
}