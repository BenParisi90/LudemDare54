using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationDoor : MonoBehaviour
{
    Interactable interactable;
    public Interactable Interactable => interactable;

    [SerializeField]
    Location destinationLocation;
    public Location DestinationLocation => destinationLocation;


    void Awake()
    {
        interactable = GetComponent<Interactable>();
        interactable.Interact += Interact;
    }

    void Interact()
    {
        if (TextController.instance.ShowingConversation == false)
        {
            LocationManager.instance.ChangeLocation(LocationManager.instance.CurrentLocation, destinationLocation);
        }
    }
}
