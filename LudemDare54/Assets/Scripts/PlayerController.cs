using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    Character character;
    public Character Character => character;
    public Interactable interactOnReachDestination;
    public Vector3 startPosition;

    void Awake()
    {
        instance = this;
        character = GetComponent<Character>();
        character.ReachedDestination += OnReachedDestination;
        character.FailedToReachDestination += OnFailedToReachDestination;
        startPosition = character.transform.position;
        
    }

    void Start()
    {
        GameState.instance.ResetGameAction += ResetGame;
    }

    public void ResetGame()
    {
        character.transform.position = startPosition;
    }

    public void AttemptWalk()
    {
        if (!TextController.instance.ShowingConversation)
        {
            Vector3 targetDestination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetDestination.z = transform.position.z;
            character.Move(targetDestination);
            Debug.Log("Set movement destination");
        }
    }

    void OnReachedDestination()
    {
        if(interactOnReachDestination == null)
        {
            return;
        }
        Debug.Log("Reached destination");
        interactOnReachDestination.AttemptInteraction();
        interactOnReachDestination = null;
    }

    void OnFailedToReachDestination()
    {
        if (interactOnReachDestination == null)
        {
            return;
        }
        Debug.Log("Failed to reach destination");
        interactOnReachDestination = null;
    }
}
