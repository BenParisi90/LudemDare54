using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    public DialogueLine[] lines;
}

[System.Serializable]
public struct DialogueLine
{
    public string text;
    public Role speaker;
}