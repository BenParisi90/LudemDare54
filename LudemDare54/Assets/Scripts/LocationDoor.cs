using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationDoor : MonoBehaviour
{
    Interactable interactable;

    [SerializeField]
    int destinationLocationIndex;

    void Awake()
    {
        interactable = GetComponent<Interactable>();
        interactable.Interact += Interact;
    }

    void Interact()
    {
        if (TextController.instance.ShowingConversation == false)
        {
            Debug.Log("Interacting with " + gameObject.name);
            Location.currentLocation.gameObject.SetActive(false);
            Location.currentLocation.transform.parent.GetChild(destinationLocationIndex).gameObject.SetActive(true);
            
        }
    }
}
