using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;

    bool[] gameEvents;
    public bool[] GameEvents => gameEvents;

    void Awake()
    {   
        instance = this;
        gameEvents = new bool[(int)GameEvent.Count];
        for(int i = 0; i < (int)GameEvent.Count; i++)
        {
           gameEvents[i] = false;
        }
    }
}

public enum GameEvent
{
    HAS_THE_SPOON,
    GAVE_NEIL_THE_SPOON,
    Count
}