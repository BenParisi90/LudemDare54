using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpOnInteract : MonoBehaviour
{
    Interactable interactable;
    [SerializeField]
    InvItem item;

    void Awake()
    {
        interactable = GetComponent<Interactable>();
        interactable.Interact += Interact;
        
    }

    void Start()
    {
        GameState.instance.ResetGameAction += ResetGame;
    }

    void ResetGame()
    {
        gameObject.SetActive(true);
    }

    void Interact()
    {
        gameObject.SetActive(false);
        InventoryManager.instance.AddItem(item);
    }
}
