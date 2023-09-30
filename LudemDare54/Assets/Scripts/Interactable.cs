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
        //if the player is farther than the interact dictance
        if (Vector3.Distance(transform.position, PlayerController.instance.character.transform.position) > interactDistance)
        {
            Vector3 targetDestination = transform.position;
            Vector3 closestPoint = Location.currentLocation.walkable.ClosestPoint(targetDestination);
            PlayerController.instance.character.Move(closestPoint, true);
        }
        else
        {
            Interact?.Invoke();
            Debug.Log("Interact");
        }
        
    }
}
