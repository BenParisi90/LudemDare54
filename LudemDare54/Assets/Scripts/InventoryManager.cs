using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    InventorySlot[] invSlots;

    //item that is being dragged
    public InvItem DraggedItem = InvItem.Count;
    public Action<InvItem> DraggedItemReleased;

    void Awake()
    {
        instance = this;
        invSlots = GetComponentsInChildren<InventorySlot>();
        
    }

    void Start()
    {
        GameState.instance.ResetGameAction += ResetGame;
    }

    void ResetGame()
    {
        foreach (InventorySlot slot in invSlots)
        {
            slot.AssignItem(InvItem.Count);
        }
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

    public void RemoveItem(InvItem item)
    {
        //find the first empty slot
        for (int i = 0; i < invSlots.Length; i++)
        {
            if (invSlots[i].Item == item)
            {
                invSlots[i].AssignItem(InvItem.Count);
                return;
            }
        }
    }

    public bool HasItem(InvItem item)
    {
        //find the first slot with the item
        for (int i = 0; i < invSlots.Length; i++)
        {
            if (invSlots[i].Item == item)
            {
                return true;
            }
        }
        return false;
    }
}

public enum InvItem
{
    SPOON,
    Count
}