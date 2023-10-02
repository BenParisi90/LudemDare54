using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractions : MonoBehaviour
{
    [SerializeField]
    ItemInteraction[] interactions;

    Interactable interactable;
    PolygonCollider2D collider;

    void Start()
    {
        interactable = GetComponent<Interactable>();
        collider = GetComponent<PolygonCollider2D>();
        InventoryManager.instance.DraggedItemReleased += OnDraggedItemReleased;
    }

    void OnDraggedItemReleased(InvItem item)
    {
        //if the mouse is overlapping the interactable
        if (collider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            if(!interactable.InInteractableRange())
            {
                interactable.AttemptInteraction();
            }
            else
            {
        
                for (int i = 0; i < interactions.Length; i++)
                {
                    if (interactions[i].item == item)
                    {
                        if (interactions[i].gameEvent != GameEvent.Count)
                        {
                            Debug.Log("Setting " + interactions[i].gameEvent + " to true");
                            GameState.instance.GameEvents[(int)interactions[i].gameEvent] = true;
                        }
                        if (interactions[i].triggerInteraction)
                        {
                            interactable.Interact();
                        }
                        if (interactions[i].removeItem)
                        {
                            InventoryManager.instance.RemoveItem(interactions[i].item);
                        }
                    }
                }
            }
        }
    }

    //If I relase the mouse on this and I am dragging an item
    void OnMouseUp()
    {
        if (InventoryManager.instance.DraggedItem != InvItem.Count)
        {
            for (int i = 0; i < interactions.Length; i++)
            {
                if (interactions[i].item == InventoryManager.instance.DraggedItem)
                {
                    
                    if (interactions[i].gameEvent != GameEvent.Count)
                    {
                        GameState.instance.GameEvents[(int)interactions[i].gameEvent] = true;
                    }
                    if (interactions[i].removeItem)
                    {
                        InventoryManager.instance.RemoveItem(interactions[i].item);
                    }
                    if (interactions[i].triggerInteraction)
                    {
                        interactable.Interact();
                    }
                }
            }
        }
    }
}

[System.Serializable]
public struct ItemInteraction
{
    public InvItem item;
    public GameEvent gameEvent;
    public bool removeItem;
    public bool triggerInteraction;
}
