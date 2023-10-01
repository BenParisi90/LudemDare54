using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactDistance = 1f;
    public Action Interact;

    //if I am clicked on, say hello
    void OnMouseDown()
    {
        if(TextController.instance.ShowingConversation)
        {
            return;
        }
        //if the player is farther than the interact dictance
        if (Vector3.Distance(transform.position, PlayerController.instance.Character.transform.position) > interactDistance)
        {
            Vector3 targetDestination = transform.position;
            Vector3 closestPoint = LocationManager.instance.CurrentLocation.walkable.ClosestPoint(targetDestination);
            PlayerController.instance.Character.Move(closestPoint, true);
            PlayerController.instance.interactOnReachDestination = this;
        }
        else
        {
            Debug.Log("Interact");
            Interact?.Invoke();
        }
        
    }
}
