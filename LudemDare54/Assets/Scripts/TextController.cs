using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public static TextController instance;
    Conversation currentConversation;
    public Conversation CurrentConversation => currentConversation;
    int currentLine = 0;
    bool showingConversation = false;
    public bool ShowingConversation => showingConversation;

    [SerializeField]
    TextMeshProUGUI textMesh;
    [SerializeField]
    Image textBackground;

    //when you click the mouse, advance the conversation
    bool conversationSetThisFrame = false;

    void Start()
    {
        instance = this;
        textMesh.text = "";
    }

    void SetText(string text)
    {
        Debug.Log("Setting text to " + text);
        textMesh.text = text;
    }

    public void SetConversation(Conversation conversation)
    {
        currentConversation = conversation;
        currentLine = 0;
        SetText(currentConversation.lines[currentLine].text);
        showingConversation = true;
        conversationSetThisFrame = true;
        textBackground.enabled = true;
    }

    void Update()
    {
        if (showingConversation && Input.GetMouseButtonDown(0) && !conversationSetThisFrame)
        {
            Debug.Log("Advancing conversation");
            currentLine++;
            if (currentLine < currentConversation.lines.Length)
            {
                SetText(currentConversation.lines[currentLine].text);
            }
            else
            {
                showingConversation = false;
                SetText("");
                textBackground.enabled = false;
            }
        }
        if(conversationSetThisFrame)
        {
            conversationSetThisFrame = false;
        }
    }
}

[System.Serializable]
public struct Conversation
{
    public DialogueLine[] lines;
}

[System.Serializable]
public struct DialogueLine
{
    public string text;
    public string speaker;
}
