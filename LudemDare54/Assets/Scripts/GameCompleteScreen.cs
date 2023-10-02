using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameCompleteScreen : MonoBehaviour
{    
    public static GameCompleteScreen instance;
    [SerializeField]
    TextMeshProUGUI endingText;
    [SerializeField]
    TextMeshProUGUI gameCompleteText;
    [SerializeField]
    Color CompletedThisRunColor;
    [SerializeField]
    Color CompletedPreviousRunColor;
    [SerializeField]
    Color NotCompletedColor;
    [SerializeField]
    AudioClip gameCompleteSound;
    [SerializeField]
    string[] eventDescriptions;

    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
        
    }

    void Start()
    {
        GameState.instance.ResetGameAction += ResetGame;
    }

    void ResetGame()
    {
        gameObject.SetActive(false);
    }

    public void ShowGameComplete(string finalText)
    {
        endingText.text = finalText;
        gameObject.SetActive(true);
        ShowStats();
        AudioManager.instance.PlaySound(gameCompleteSound);
    }

    public void ShowStats()
    {
        gameCompleteText.text = "";
        int eventCount = 0;
        //for every game event
        for(int i = 0; i < (int)GameEvent.Count; i++)
        {
            string eventDescription = eventDescriptions[i];
            //if the game event is true
            if(GameState.instance.GameEvents[i])
            {
                //add the game event to the text with the completed color
                gameCompleteText.text += "\n<color=#" + ColorUtility.ToHtmlStringRGB(CompletedThisRunColor) + ">" + eventDescription + "</color>";
                //save that you have completed the event in player prefs
                PlayerPrefs.SetInt(((GameEvent)i).ToString(), 1);
                eventCount++;
            }
            //otherwise, if i completed the even on a previous run
            else if(PlayerPrefs.GetInt(((GameEvent)i).ToString(), 0) == 1)
            {
                //add the game event to the text with the completed previous run color
                gameCompleteText.text += "\n<color=#" + ColorUtility.ToHtmlStringRGB(CompletedPreviousRunColor) + ">" + eventDescription + "</color>";
                eventCount++;
            }
            else
            {
                //add the game event to the text with the not completed color
                gameCompleteText.text += "\n<color=#" + ColorUtility.ToHtmlStringRGB(NotCompletedColor) + ">" + eventDescription + "</color>";
            }
        }
        float percent = (float)eventCount / (float)GameEvent.Count;
        if(percent == 1f)
        {
            gameCompleteText.text += "\n<color=#" + ColorUtility.ToHtmlStringRGB(CompletedThisRunColor) + ">100% Completed</color>";
        }
        else
        {
            gameCompleteText.text += "\n<color=#" + ColorUtility.ToHtmlStringRGB(NotCompletedColor) + ">" + Mathf.RoundToInt(percent * 100f) + "% Completed</color>";
        }
    }
}
