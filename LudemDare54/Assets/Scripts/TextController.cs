using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class TextController : MonoBehaviour
{
    public static TextController instance;
    Conversation currentConversation;
    public Conversation CurrentConversation => currentConversation;
    int currentLine = 0;
    bool showingConversation = false;
    public bool ShowingConversation => showingConversation;
    bool revealingText = false;
    float charRevealTime = 0.05f;
    float defaultCharRevealTime = 0.05f;



    [SerializeField]
    TextMeshProUGUI textMesh;
    [SerializeField]
    Image textBackground;
    [SerializeField]
    Image speakerImage;
    [SerializeField]
    Sprite[] speakers;

    //when you click the mouse, advance the conversation
    bool conversationSetThisFrame = false;

    void Start()
    {
        instance = this;
        textMesh.text = "";
        textBackground.gameObject.SetActive(false);
    }

    void SetText(string text)
    {
        Debug.Log("Setting text to " + text);
        StartCoroutine(RevealText(text));
    }

    IEnumerator RevealText(string text)
    {
        revealingText = true;
        textMesh.text = "";
        charRevealTime = defaultCharRevealTime;
        for (int i = 0; i < text.Length; i++)
        {
            textMesh.text += text[i];
            yield return new WaitForSeconds(charRevealTime); // adjust the delay between characters here
        }
        revealingText = false;
    }

    public void SetConversation(Conversation conversation)
    {
        currentConversation = conversation;
        currentLine = 0;
        ShowLine(currentConversation.lines[currentLine]);
        showingConversation = true;
        conversationSetThisFrame = true;
        textBackground.gameObject.SetActive(true);
    }

    void Update()
    {
        if (showingConversation)
        {
            if(Input.GetMouseButtonDown(0) && !conversationSetThisFrame)
            {
                if(revealingText)
                {
                    charRevealTime = 0f;
                }
                else
                {
                    Debug.Log("Advancing conversation");
                    currentLine++;
                    if (currentLine < currentConversation.lines.Length)
                    {
                        ShowLine(currentConversation.lines[currentLine]);
                    }
                    else
                    {
                        showingConversation = false;
                        SetText("");
                        textBackground.gameObject.SetActive(false);
                        if(currentConversation.gameEvent != GameEvent.Count)
                        {
                            GameState.instance.GameEvents[(int)currentConversation.gameEvent] = true;
                        }
                        if(currentConversation.finalText != "")
                        {
                            GameCompleteScreen.instance.ShowGameComplete(currentConversation.finalText);
                        }
                    }
                }
            }
        }
        if(conversationSetThisFrame)
        {
            conversationSetThisFrame = false;
        }
    }

    void ShowLine(DialogueLine dialogueLine)
    {
        SetText(dialogueLine.text);
        speakerImage.sprite = speakers[(int)dialogueLine.speaker];
    }
}