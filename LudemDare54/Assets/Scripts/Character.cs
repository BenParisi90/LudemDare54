using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Vector3 destination;
    float speed = 5f;
    public Action ReachedDestination;
    public Action FailedToReachDestination;

    void Start()
    {
        ResetDestination();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            return;
        }
        float scaledSpeed = speed * transform.localScale.x  * Time.deltaTime;
        //move the character towards the destination
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, destination, scaledSpeed);
        //if the next position is a valid place to stand
        if (LocationManager.instance.CurrentLocation.IsValidWalkDestination(nextPosition))
        {
            LocationManager.instance.CurrentLocation.walkable.PlaceCharacter(this, nextPosition);
            //if the character has reached the destination
            if (Vector3.Distance(transform.position, destination) < 0.01f)
            {
                //stop moving
                ReachedDestination?.Invoke();
                ResetDestination();
                Debug.Log("Reached destination");
            }
        }
        else
        {
            FailedToReachDestination?.Invoke();
            ResetDestination();
            Debug.Log("Failed to reach destination");
        }      
    }

    public void Move(Vector3 targetDestination, bool force = false)
    {
        if (force || LocationManager.instance.CurrentLocation.IsValidWalkDestination(targetDestination))
        {
            destination = targetDestination;
        }
    }

    public void ResetDestination()
    {
        destination = transform.position;
    }
}
