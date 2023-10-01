using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    bool[] gameEvents;
    public bool[] GameEvents => gameEvents;

    public Action ResetGameAction;

    void Awake()
    {   
        instance = this;
        gameEvents = new bool[(int)GameEvent.Count];
        ResetGame();
    }

    public void ResetGame()
    {
        ResetGameAction?.Invoke();
        for(int i = 0; i < (int)GameEvent.Count; i++)
        {
           gameEvents[i] = false;
        }
    }

    public void ResetStats()
    {
        PlayerPrefs.DeleteAll();
        for(int i = 0; i < (int)GameEvent.Count; i++)
        {
           gameEvents[i] = false;
        }
    }
}

public enum GameEvent
{
    GAVE_NEIL_THE_SPOON,
    LOOKED_OUT_THE_WINDOW,
    THREW_SPOON_OUT_WINDOW,
    Count
}