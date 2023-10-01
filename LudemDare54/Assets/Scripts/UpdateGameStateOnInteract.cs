using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGameStateOnInteract : MonoBehaviour
{
    [SerializeField]
    GameEvent gameEvent;
    
    Interactable interactable;

    void Start()
    {
        interactable = GetComponent<Interactable>();
        interactable.Interact += Interact;
    }

    void Interact()
    {
        GameState.instance.GameEvents[(int)gameEvent] = true;
    }
}
