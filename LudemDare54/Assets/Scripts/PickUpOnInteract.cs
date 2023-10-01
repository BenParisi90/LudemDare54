using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpOnInteract : MonoBehaviour
{
    Interactable interactable;
    [SerializeField]
    InvItem item;

    void Start()
    {
        interactable = GetComponent<Interactable>();
        interactable.Interact += Interact;
    }

    void Interact()
    {
        gameObject.SetActive(false);
        InventoryManager.instance.AddItem(item);
    }
}
