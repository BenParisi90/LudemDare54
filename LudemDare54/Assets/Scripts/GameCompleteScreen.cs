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
    TextMeshProUGUI gameCompleteText;
    [SerializeField]
    Color CompletedThisRunColor;
    [SerializeField]
    Color CompletedPreviousRunColor;
    [SerializeField]
    Color NotCompletedColor;

    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    public void ShowGameComplete()
    {
        gameObject.SetActive(true);
        gameCompleteText.text = "You have completed the game!";

        //for every game event
        for(int i = 0; i < (int)GameEvent.Count; i++)
        {
            //if the game event is true
            if(GameState.instance.GameEvents[i])
            {
                //add the game event to the text with the completed color
                gameCompleteText.text += "\n<color=#" + ColorUtility.ToHtmlStringRGB(CompletedThisRunColor) + ">" + ((GameEvent)i).ToString() + "</color>";
                //save that you have completed the event in player prefs
                PlayerPrefs.SetInt(((GameEvent)i).ToString(), 1);
            }
            //otherwise, if i completed the even on a previous run
            else if(PlayerPrefs.GetInt(((GameEvent)i).ToString(), 0) == 1)
            {
                //add the game event to the text with the completed previous run color
                gameCompleteText.text += "\n<color=#" + ColorUtility.ToHtmlStringRGB(CompletedPreviousRunColor) + ">" + ((GameEvent)i).ToString() + "</color>";
            }
            else
            {
                //add the game event to the text with the not completed color
                gameCompleteText.text += "\n<color=#" + ColorUtility.ToHtmlStringRGB(NotCompletedColor) + ">" + ((GameEvent)i).ToString() + "</color>";
            }
        }
    }
}
