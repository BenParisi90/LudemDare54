using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOnInteract : MonoBehaviour
{
    [SerializeField]
    Conversation conversation;

    Interactable interactable;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        interactable.Interact += Interact;
    }

    void Interact()
    {
        if(TextController.instance.ShowingConversation == false)
        {
            Debug.Log("Interacting with " + gameObject.name);
            TextController.instance.SetConversation(conversation);

        }
        
    }
}