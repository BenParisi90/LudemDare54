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

    //if I pressed the d button, log out the game state
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            for(int i = 0; i < (int)GameEvent.Count; i++)
            {
                Debug.Log((GameEvent)i + ": " + gameEvents[i]);
            }
        }
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
    HAS_MET_OBAMA_AND_TAYLOR_SWIFT,
    GAVE_KIM_THE_SPOON,
    SOLD_MARK_THE_MEAT,
    TOLD_ELON_ABOUT_TAYLORS_LEGS,
    GAVE_TAYLOR_SWIFT_THE_ROBOT_LEGS,
    Count
}