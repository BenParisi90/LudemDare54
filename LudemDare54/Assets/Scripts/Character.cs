using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Vector3 destination;
    float speed = 5f;

    void Start()
    {
        ResetDestination();
    }
    void Update()
    {
        float scaledSpeed = speed * transform.localScale.x  * Time.deltaTime;
        //move the character towards the destination
        LocationManager.instance.CurrentLocation.walkable.PlaceCharacter(this, Vector3.MoveTowards(transform.position, destination, scaledSpeed));
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
