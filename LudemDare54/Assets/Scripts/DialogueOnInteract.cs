using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOnInteract : MonoBehaviour
{
    [SerializeField]
    ConditionalConversation[] conversations;

    Interactable interactable;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        interactable.Interact += Interact;
    }

    void Interact()
    {
        if(TextController.instance.ShowingConversation)
        {
            return;
        }
        foreach(ConditionalConversation conditionalConversation in conversations)
        {
            bool allConditionsMet = true;
            foreach(GameEvent gameEvent in conditionalConversation.conditions)
            {
                if(!GameState.instance.GameEvents[(int)gameEvent])
                {
                    allConditionsMet = false;
                    break;
                }
            }
            if(allConditionsMet)
            {
                TextController.instance.SetConversation(conditionalConversation.conversation);
                return;
            }
        }
        Debug.Log("Interacting with " + gameObject.name);
    }
}

[System.Serializable]
public struct ConditionalConversation
{
    public GameEvent[] conditions;
    public Conversation conversation;
}