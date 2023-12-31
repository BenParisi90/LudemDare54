using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Interactable : MonoBehaviour
{
    public float interactDistance = 1f;
    public Action Interact;

    [SerializeField] 
    Vector3 interactionOffset;
    public Vector3 InteractionOffset => interactionOffset;

    [SerializeField]
    BlockingItemCondition[] blockingConditions;
    [SerializeField]
    BlockingGameEventCondition[] blockingGameEventConditions;

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + interactionOffset, 0.1f);
        interactionOffset = Handles.PositionHandle(transform.position + interactionOffset, Quaternion.identity) - transform.position;
    }
#endif

    //if I am clicked on, say hello
    void OnMouseDown()
    {
        AttemptInteraction();
    }

    public void AttemptInteraction()
    {
        if(TextController.instance.ShowingConversation)
        {
            return;
        }
        //if the player is farther than the interact dictance
        if (!InInteractableRange())
        {
            Vector3 closestPoint = LocationManager.instance.CurrentLocation.walkable.ClosestPoint(transform.position + interactionOffset);
            PlayerController.instance.Character.Move(closestPoint, true);
            PlayerController.instance.interactOnReachDestination = this;
        }
        else
        {
            foreach (BlockingItemCondition blockingCondition in blockingConditions)
            {
                if (InventoryManager.instance.HasItem(blockingCondition.invItem) == blockingCondition.hasItem)
                {
                    TextController.instance.SetConversation(blockingCondition.conversation);
                    return;
                }
            }
            foreach (BlockingGameEventCondition blockingGameEventCondition in blockingGameEventConditions)
            {
                if (GameState.instance.GameEvents[(int)blockingGameEventCondition.gameEvent] == blockingGameEventCondition.eventComplete)
                {
                    TextController.instance.SetConversation(blockingGameEventCondition.conversation);
                    return;
                }
            }
            
                
            Debug.Log("Interact");
            Interact?.Invoke();
        }
    }

    public bool InInteractableRange()
    {
        return Vector3.Distance(transform.position + interactionOffset, PlayerController.instance.Character.transform.position) <= interactDistance;
    }
}

[System.Serializable]
public struct BlockingItemCondition
{
    public InvItem invItem;
    public bool hasItem;
    public Conversation conversation;
}

[System.Serializable]
public struct BlockingGameEventCondition
{
    public GameEvent gameEvent;
    public bool eventComplete;
    public Conversation conversation;
}