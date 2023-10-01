using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    [SerializeField]
    List<InvSlot> invSlots;

    void Awake()
    {
        instance = this;
        for (int i = 0; i < invSlots.Count; i++)
        {
            assignItem(invSlots[i], invSlots[i].item);
        }
    }

    public void AddItem(InvItem item)
    {
        //find the first empty slot
        for (int i = 0; i < invSlots.Count; i++)
        {
            if (invSlots[i].item == InvItem.Count)
            {
                var slot = invSlots[i];
                slot.item = item;
                assignItem(slot, item);

                invSlots[i] = slot;
                return;
            }
        }
    }

    void assignItem(InvSlot slot, InvItem item)
    {
        //loop thorugh the children of the slot and turn on the correct item
        for (int j = 0; j < slot.slot.childCount; j++)
        {
            slot.slot.GetChild(j).gameObject.SetActive(j == (int)item);
        }
    }
}

public enum InvItem
{
    SPOON,
    Count
}

[System.Serializable]
public struct InvSlot
{
    public Transform slot;
    public InvItem item;
}